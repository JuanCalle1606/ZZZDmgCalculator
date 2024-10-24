namespace ZZZDmgCalculator.Models.State;

using Abstractions;
using Enum;
using Info;
using Util;
using static Enum.Stats;
using Enum=System.Enum;

public class AgentState : IModifierContainer {
	CoreSkills _coreSkillLevel;
	AscensionState _ascension;
	EngineState? _engine;

	Dictionary<Stats, StatModifier> _baseStats = new();
	StatModifier[] _coreStats = new StatModifier[2];

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
			UpdateAll();
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

			UpdateAll();
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

	public IModifierContainer? Parent { get; set; } = null;

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
			UpdateAll();
		}
	}

	public DiscState?[] Discs { get; } = new DiscState?[6];

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

		UpdateAll();
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
		_baseStats[Mastery] = new() { Stat = Mastery, Value = Info.FinalStats[2] };
		_baseStats[Proficiency] = new() { Stat = Proficiency, Value = Info.FinalStats[3] };
		_baseStats[EnergyRegen] = new() { Stat = EnergyRegen, Value = Info.FinalStats[4] };

		_coreStats[0] = new() { Stat = Info.CoreStats[0].Stat };
		_coreStats[1] = new() { Stat = Info.CoreStats[1].Stat };
	}

	void UpdateBaseStats(bool update = true) {
		// reset all stat
		Stats.Base.Reset();

		IModifierContainer container = this;
		foreach (var stat in container.AllModifiers.Where(m => m.Type == StatModifiers.Base))
		{
			Stats.Base[stat.Stat] += stat.Value;
		}

		if (update) Stats.Update();
	}

	public void UpdateAll() {
		UpdateBaseStats(false);
		UpdateBonusStats(false);
		Stats.Update();
	}

	void UpdateBonusStats(bool update = true) {
		Stats.Bonus.Reset();

		IModifierContainer container = this;
		var percent = container.AllModifiers
			.Where(m => m.Type == StatModifiers.BasePercent)
			.GroupBy(mod => mod.Stat)
			.Select(group => new KeyValuePair<Stats, double>(group.Key, group.Sum(mod => mod.Value)));

		foreach (var perPair in percent)
		{
			// values are in percent need to be converted to decimal + 1
			var mod = perPair.Value / 100 + 1;
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
		
		if (update) Stats.Update();
	}
}