namespace ZZZDmgCalculator.Models.State;

using System.Text.Json.Serialization;
using Abstractions;
using Enum;
using Info;
using Json;
using Util;
using static Enum.Stats;
using Enum=System.Enum;

[JsonConverter(typeof(AgentSerializer))]
public class AgentState : IModifierContainer, IBuffContainer {
	CoreSkills _coreSkillLevel;
	AscensionState _ascension;
	EngineState? _engine;

	readonly Dictionary<Stats, StatModifier> _baseStats = new();
	readonly StatModifier[] _coreStats = new StatModifier[2];

	/**
	 * To improve the performance a little bit, we can use a flag to indicate if the agent is currently loading,
	 * so we can skip the update process until the agent is fully loaded.
	 */
	internal bool Loading;

	public AgentInfo Info { get; }

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

			foreach (var buff in _coreBuffs)
			{
				buff.Scale = num;
			}

			UpdateAllStats();
		}
	}

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

	readonly List<IModifierContainer> _modChildren = [];

	IEnumerable<IModifierContainer> IModifierContainer.Children => _modChildren;

	readonly List<IBuffContainer> _buffChildren = [];

	BuffState[] _coreBuffs = null!;
	BuffState[] _additionalBuffs = null!;

	IEnumerable<IBuffContainer> IBuffContainer.Children => _buffChildren;

	public BuffSource Source => BuffSource.Agent;

	public List<BuffState> Buffs { get; } = [];

	public IBuffContainer? SharedContainer { get; set; }

	public EngineState? Engine
	{
		get => _engine;
		set
		{
			if (_engine is not null)
			{
				_modChildren.Remove(_engine);
				_buffChildren.Remove(_engine);
			}
			_engine = value;
			if (_engine is not null)
			{
				_modChildren.Add(_engine);
				_buffChildren.Add(_engine);
				_engine.CheckDependencies(true);
				_engine.UpdateOwner(this);
			}
			UpdateAllStats();
		}
	}

	public DiscState?[] Discs { get; } = new DiscState?[6];

	/**
	 * Disc sets of the agent, there is a maximum of 3 disc sets, this means that the agent has 3 pairs of different discs.
	 * The full set is when the agent has 4 discs of the same type.
	 */
	List<DiscSetState> DiscSets { get; } = new(3);

	public AgentState(AgentInfo info) {
		Info = info;

		InitBaseStats();

		foreach (var baseStat in _baseStats)
		{
			Modifiers.Add(baseStat.Value);
		}
		foreach (var coreStat in _coreStats)
		{
			Modifiers.Add(coreStat);
		}

		InitBuffs();
		UpdateAllStats();
	}

	public void SetDisc(DiscState? disc, int i) {
		if (Discs[i] is {} d)
			_modChildren.Remove(d);
		else if (disc is null)
			// both disc and current disc are null
			return;
		Discs[i] = disc;
		if (Discs[i] is {} d2)
			_modChildren.Add(d2);
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
					_buffChildren.Add(set);
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
				_buffChildren.Remove(set);
			}
		}

		RemoveDiscSet(halfSets);
		AddDiscSet(halfSets);
	}

	public void SetAdditionalStatus(bool status) {
		var current = _additionalBuffs.Any(b => b.Available);
		if (current == status) return;

		foreach (var buff in _additionalBuffs)
		{
			buff.Available = status;
		}
		UpdateAllStats();
	}

	void InitBuffs() {
		_coreBuffs = Info.CoreBuff.Select(b => new BuffState(b)
		{
			SourceInfo = Info,
			Owner = this
		}).ToArray();
		_additionalBuffs = Info.AdditionalBuff.Select(b => new BuffState(b)
		{
			SourceInfo = Info,
			Owner = this
		}).ToArray();
		Buffs.AddRange(_coreBuffs);
		Buffs.AddRange(_additionalBuffs);
	}

	void AddDiscSet(IGrouping<Discs, DiscState?>[] halfSets) {
		// when a disc is added whe need to add a possible set to the list
		var toadd = halfSets.Select(s => s.Key).Except(DiscSets.Select(ds => ds.Disc)).Cast<Discs?>().FirstOrDefault();
		if (toadd is null) return;
		var set = new DiscSetState(halfSets.First(s => s.Key == toadd).First()!.Info);
		DiscSets.Add(set);
		_modChildren.Add(set);
		foreach (var buff in set.Buffs)
		{
			buff.Owner = this;
		}
	}

	void RemoveDiscSet(IGrouping<Discs, DiscState?>[] halfSets) {
		// when a disc is removed, we need to check if the set is still valid
		var toremove = DiscSets.Select(d => d.Disc).Except(halfSets.Select(s => s.Key)).Cast<Discs?>().FirstOrDefault();
		if (toremove is null) return;

		var set = DiscSets.First(ds => ds.Disc == toremove);
		DiscSets.Remove(set);
		_modChildren.Remove(set);
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
		Stats.Update(false);
		UpdateCombatStats();
		Stats.Update();
	}
	void UpdateCombatStats() {
		Stats.Combat.Reset();

		var percent = ListModifiers(StatModifiers.CombatPercent)
			.GroupBy(mod => mod.Stat)
			.Select(group => new KeyValuePair<Stats, double>(group.Key, group.Sum(mod => mod.Value)));

		foreach (var perPair in percent)
		{
			// values are in percent need to be converted to decimal + 1
			var mod = perPair.Value / 100;
			Stats.Combat[perPair.Key] = Stats.Initial[perPair.Key] * mod;
		}

		var flat = ListModifiers(StatModifiers.CombatFlat)
			.GroupBy(mod => mod.Stat)
			.Select(group => new KeyValuePair<Stats, double>(group.Key, group.Sum(mod => mod.Value)));

		foreach (var flatPair in flat)
		{
			Stats.Combat[flatPair.Key] += flatPair.Value;
		}

		var flat2 = ListModifiers(StatModifiers.Combat)
			.GroupBy(mod => mod.Stat)
			.Select(group => new KeyValuePair<Stats, double>(group.Key, group.Sum(mod => mod.Value)));

		foreach (var flatPair in flat2)
		{
			Stats.Combat[flatPair.Key] += flatPair.Value;
		}
	}

	void UpdateBaseStats() {
		// reset all stat
		Stats.Base.Reset();

		foreach (var stat in ListModifiers(StatModifiers.Base))
		{
			Stats.Base[stat.Stat] += stat.Value;
		}
	}

	IEnumerable<StatModifier> ListModifiers(StatModifiers modifier) {
		IModifierContainer container = this;
		IBuffContainer buffContainer = this;


		return container.AllModifiers
			.Concat(buffContainer.AllBuffs.Where(b => b is { Available: true, Active: true }).SelectMany(b => {
				// sometimes shared buffs have not shared modifiers
				if (b.Shared && b.Owner != this)
					return b.Modifiers.Where(m => m.Shared);
				return b.Modifiers;
			}))
			.Where(m => m.Type == modifier && m is { Enemy: false, Agent: false });
	}

	void UpdateBonusStats() {
		Stats.Bonus.Reset();

		var percent = ListModifiers(StatModifiers.BasePercent)
			.GroupBy(mod => mod.Stat)
			.Select(group => new KeyValuePair<Stats, double>(group.Key, group.Sum(mod => mod.Value)));

		foreach (var perPair in percent)
		{
			// values are in percent need to be converted to decimal + 1
			var mod = perPair.Value / 100;
			Stats.Bonus[perPair.Key] = Stats.Base[perPair.Key] * mod;
		}

		var flat = ListModifiers(StatModifiers.BaseFlat)
			.GroupBy(mod => mod.Stat)
			.Select(group => new KeyValuePair<Stats, double>(group.Key, group.Sum(mod => mod.Value)));

		foreach (var flatPair in flat)
		{
			Stats.Bonus[flatPair.Key] += flatPair.Value;
		}
	}
}