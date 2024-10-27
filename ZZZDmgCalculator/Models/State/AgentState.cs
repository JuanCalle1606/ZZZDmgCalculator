namespace ZZZDmgCalculator.Models.State;

using System.Text.Json.Serialization;
using Abstractions;
using Enum;
using Info;
using Json;
using Services;
using Util;
using static Enum.Stats;
using Enum=System.Enum;

[JsonConverter(typeof(AgentSerializer))]
public class AgentState : IModifierContainer {
	CoreSkills _coreSkillLevel;
	AscensionState _ascension;
	EngineState? _engine;

	Dictionary<Stats, StatModifier> _baseStats = new();
	StatModifier[] _coreStats = new StatModifier[2];

	/**
	 * To improve the performance a little bit, we can use a flag to indicate if the agent is currently loading,
	 * so we can skip the update process until the agent is fully loaded.
	 */
	internal bool Loading;

	public AgentInfo Info { get; }

	public Agents Agent { get; }

	public AscensionState Ascension
	{
		get => _ascension;
		set
		{
			_ascension = value;
			_baseStats[Atk].Value = Info.BaseStats[0][(int)_ascension];
			_baseStats[Hp].Value = Info.BaseStats[1][(int)_ascension];
			_baseStats[Def].Value = Info.BaseStats[2][(int)_ascension];
			UpdateAllStats();
		}
	}

	public int Cinema { get; set; }

	public CoreSkills CoreSkillLevel
	{
		get => _coreSkillLevel;
		set
		{
			_coreSkillLevel = value;

			// Core skill values
			var core1 = Info.CoreStats[0];
			var core2 = Info.CoreStats[1];

			var num = (int)_coreSkillLevel;

			_coreStats[0].Value = core1.Value * (num switch
			{
				1 or 2 => 1,
				3 or 4 => 2,
				5 or 6 => 3,
				_ => 0
			});
			_coreStats[1].Value = core2.Value * (num switch
			{
				2 or 3 => 1,
				4 or 5 => 2,
				6 => 3,
				_ => 0
			});

			UpdateAllStats();
		}
	}

	static int ObtenerResultado(int num) => num is 1 or 2 ? 1 : num is 3 or 4 ? 2 : num is 5 or 6 ? 3 : 0;

	public EntityState Stats { get; } = new();

	/// <summary>
	/// The skill levels of the agent.
	/// 0: Basic Attack
	/// 1: Dodge
	/// 2: Assist
	/// 3: Special
	/// 4: Ultimate
	/// </summary>
	public int[] SkillLevels { get; private set; } = [1, 1, 1, 1, 1];

	public IList<StatModifier> Modifiers { get; } = new List<StatModifier>();

	readonly List<IModifierContainer> _children = [];

	IEnumerable<IModifierContainer> IModifierContainer.Children => _children;

	public EngineState? Engine
	{
		get => _engine;
		set
		{
			if (_engine is not null)
				_children.Remove(_engine);
			_engine = value;
			if (_engine is not null)
				_children.Add(_engine);
			UpdateAllStats();
		}
	}

	public DiscState?[] Discs { get; } = new DiscState?[6];

	/**
	 * Disc sets of the agent, there is a maximum of 3 disc sets, this means that the agent has 3 pairs of different discs.
	 * The full set is when the agent has 4 discs of the same type.
	 */
	public List<DiscSetState> DiscSets { get; } = new(3);

	public void SetDisc(DiscState? disc, int i) {
		if (Discs[i] is {} d)
			_children.Remove(d);
		else if (disc is null)
			// both disc and current disc are null
			return;
		Discs[i] = disc;
		if (Discs[i] is {} d2)
			_children.Add(d2);
		CheckDiscSets();
		UpdateAllStats();
	}
	
	void CheckDiscSets() {
		var discGroups = Discs.Where(d => d is not null)
			.GroupBy(d => d!.Disc).ToArray();

		var fullSet = discGroups.FirstOrDefault(g => g.Count() >= 4);
		var halfSets = discGroups.Where(g => g.Count() >= 2).ToArray();

		if (fullSet is not null)
		{
			// when the disc #4 is added, the full set is completed but already exists in the set list for the 2-piece bonus
			var set = DiscSets.FirstOrDefault(ds => ds.Disc == fullSet.Key);
			// in theory, the set should never be null, but just in case
			if (set is not null)
			{
				// when 5th or 6th piece is added, the set is already completed so no need to update it
				if (!set.FullSet)
				{
					set.FullSet = true;
				}
			}
		}
		else
		{
			// when the 4th piece is removed, the full set is no longer completed
			var set = DiscSets.FirstOrDefault(ds => ds.FullSet);
			if (set is not null)
			{
				set.FullSet = false;
			}
		}

		RemoveDiscSet(halfSets);
		AddDiscSet(halfSets);
	}

	void AddDiscSet(IGrouping<Discs, DiscState?>[] halfSets) {
		// when a disc is added whe need to add a possible set to the list
		var toadd = halfSets.Select(s => s.Key).Except(DiscSets.Select(ds => ds.Disc)).Cast<Discs?>().FirstOrDefault();
		if (toadd is null) return;
		var set = new DiscSetState(halfSets.First(s => s.Key == toadd).First()!.Info);
		DiscSets.Add(set);
		_children.Add(set);
	}

	void RemoveDiscSet(IGrouping<Discs, DiscState?>[] halfSets) {
		// when a disc is removed, we need to check if the set is still valid
		var toremove = DiscSets.Select(d => d.Disc).Except(halfSets.Select(s => s.Key)).Cast<Discs?>().FirstOrDefault();
		if (toremove is null) return;
		
		var set = DiscSets.First(ds => ds.Disc == toremove);
		DiscSets.Remove(set);
		_children.Remove(set);
	}

	public AgentState(AgentInfo info) {
		Info = info;
		Agent = Enum.Parse<Agents>(info.Id);

		InitBaseStats();

		foreach (var baseStat in _baseStats)
		{
			Modifiers.Add(baseStat.Value);
		}
		foreach (var coreStat in _coreStats)
		{
			Modifiers.Add(coreStat);
		}

		UpdateAllStats();
	}

	void InitBaseStats() {
		// Initialize base stats
		_baseStats[Atk] = new() { Stat = Atk, Value = Info.BaseStats[0][(int)_ascension] };
		_baseStats[Hp] = new() { Stat = Hp, Value = Info.BaseStats[1][(int)_ascension] };
		_baseStats[Def] = new() { Stat = Def, Value = Info.BaseStats[2][(int)_ascension] };

		_baseStats[CritDmg] = new() { Stat = CritDmg, Value = 50 };
		_baseStats[CritRate] = new() { Stat = CritRate, Value = 5 };
		_baseStats[Pen] = new() { Stat = Pen, Value = 0 };

		_baseStats[PenRatio] = new() { Stat = PenRatio, Value = Info.FinalStats[0] };
		_baseStats[Impact] = new() { Stat = Impact, Value = Info.FinalStats[1] };
		_baseStats[Proficiency] = new() { Stat = Proficiency, Value = Info.FinalStats[2] };
		_baseStats[Mastery] = new() { Stat = Mastery, Value = Info.FinalStats[3] };
		_baseStats[EnergyRegen] = new() { Stat = EnergyRegen, Value = Info.FinalStats[4] };

		_coreStats[0] = new() { Stat = Info.CoreStats[0].Stat };
		_coreStats[1] = new() { Stat = Info.CoreStats[1].Stat };
	}

	public void UpdateAllStats() {
		if (Loading) return;
		UpdateBaseStats();
		UpdateBonusStats();
		Stats.Update();
	}

	void UpdateBaseStats() {
		// reset all stat
		Stats.Base.Reset();

		IModifierContainer container = this;
		foreach (var stat in container.AllModifiers.Where(m => m.Type == StatModifiers.Base))
		{
			Stats.Base[stat.Stat] += stat.Value;
		}
	}

	void UpdateBonusStats() {
		Stats.Bonus.Reset();

		IModifierContainer container = this;
		var percent = container.AllModifiers
			.Where(m => m.Type == StatModifiers.BasePercent)
			.GroupBy(mod => mod.Stat)
			.Select(group => new KeyValuePair<Stats, double>(group.Key, group.Sum(mod => mod.Value)));

		foreach (var perPair in percent)
		{
			// values are in percent need to be converted to decimal + 1
			var mod = perPair.Value / 100;
			Stats.Bonus[perPair.Key] = Stats.Base[perPair.Key] * mod;
		}

		var flat = container.AllModifiers
			.Where(m => m.Type == StatModifiers.BaseFlat)
			.GroupBy(mod => mod.Stat)
			.Select(group => new KeyValuePair<Stats, double>(group.Key, group.Sum(mod => mod.Value)));

		foreach (var flatPair in flat)
		{
			Stats.Bonus[flatPair.Key] += flatPair.Value;
		}
	}
}