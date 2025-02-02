namespace ZZZDmgCalculator.Models.State;

using Abstractions;
using Enum;
using Extensions;
using Info;
using static Enum.Stats;

public class EnemyState : IModifierContainer, IBuffContainer {

	readonly Dictionary<Stats, StatModifier> _baseStats = new();
	int _level = 1;
	int _baseDefense;
	int _stunMultiplier = 150;

	public EntityState Stats { get; } = new();

	public int Level
	{
		get => _level;
		set
		{
			_level = value;
			BaseDefense = _baseDefense;// Assigning to itself to trigger the update
		}
	}

	public bool Stunned { get; set; }

	public int StunMultiplier
	{
		get => _stunMultiplier;
		set
		{
			_stunMultiplier = value;
			_baseStats[StunDmg].Value = value;
			UpdateAllStats();
		}
	}

	public List<Attributes> Resistances { get; } = [];

	public List<Attributes> Weaknesses { get; } = [];

	public int BaseDefense
	{
		get => _baseDefense;
		set
		{
			_baseDefense = value;
			var level = Math.Min(_level, 60);
			var levelFactor = Math.Floor(0.1551 * level * level + 3.141 * level + 47.2039);
			_baseStats[Def].Value = (_baseDefense * levelFactor) / 50;
			UpdateAllStats();
		}
	}

	public BuffSource Source => BuffSource.Enemy;

	public List<BuffState> Buffs { get; } = [];

	public IBuffContainer? SharedContainer { get; }

	public IList<StatModifier> Modifiers { get; } = new List<StatModifier>();

	public EnemyState(IBuffContainer? container = null) {
		SharedContainer = container;

		InitBaseStats();

		BaseDefense = 36;// This triggers the update
	}
	
	void InitBaseStats() {
		_baseStats[Def] = new() { Stat = Def, Value = BaseDefense };
		_baseStats[StunDmg] = new() { Stat = StunDmg, Value = StunMultiplier };
		_baseStats[ElectricRes] = new() { Stat = ElectricRes, Value = 0 };
		_baseStats[IceRes] = new() { Stat = IceRes, Value = 0 };
		_baseStats[FireRes] = new() { Stat = FireRes, Value = 0 };
		_baseStats[EtherRes] = new() { Stat = EtherRes, Value = 0 };
		_baseStats[PhysicalRes] = new() { Stat = PhysicalRes, Value = 0 };

		foreach (var baseStat in _baseStats)
		{
			Modifiers.Add(baseStat.Value);
		}
	}

	public void UpdateResistances() {
		_baseStats[ElectricRes].Value = 0;
		_baseStats[IceRes].Value = 0;
		_baseStats[FireRes].Value = 0;
		_baseStats[EtherRes].Value = 0;
		_baseStats[PhysicalRes].Value = 0;
		
		foreach (var stat in Resistances.Select(AttributesToStat))
		{
			_baseStats[stat].Value -= 20;
		}
		
		foreach (var stat in Weaknesses.Select(AttributesToStat))
		{
			_baseStats[stat].Value += 20;
		}
		
		UpdateAllStats();
	}
	
	Stats AttributesToStat(Attributes attribute) {
		return attribute switch
		{
			Attributes.Electric => ElectricRes,
			Attributes.Ice => IceRes,
			Attributes.Fire => FireRes,
			Attributes.Ether => EtherRes,
			Attributes.Physical => PhysicalRes,
			_ => throw new ArgumentOutOfRangeException(nameof(attribute), attribute, null)
		};
	}

	public void UpdateAllStats() {
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

	void UpdateBaseStats() {
		Stats.Base.Reset();

		foreach (var stat in ListModifiers(StatModifiers.Base))
		{
			Stats.Base[stat.Stat] += stat.Value;
		}
	}

	IEnumerable<StatModifier> ListModifiers(StatModifiers modifier) {
		IModifierContainer container = this;

		return container.AllModifiers
			.Concat(SharedContainer!.Children.SelectMany(c => c.SelfBuffs)
				.Where(b => b is { Available: true, Active: true, Info.SkillCondition: null, Info.AbilityCondition: null })
				.SelectMany(b => b.Modifiers.Where(m => m.Enemy)))
			.Where(m => m.Type == modifier);
	}

}