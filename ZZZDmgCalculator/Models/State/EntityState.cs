namespace ZZZDmgCalculator.Models.State;

using Enum;
using Info;
using Enum=System.Enum;

/**
 * Holds the stats of an entity
 */
public class EntityState {
	
	public readonly Dictionary<Stats, double> Base = ZeroStats();

	public readonly Dictionary<Stats, double> BasePercent = ZeroStats();

	public readonly Dictionary<Stats, double> BaseFlat = ZeroStats();

	public readonly Dictionary<Stats, double> CombatPercent = ZeroStats();

	public readonly Dictionary<Stats, double> CombatFlat = ZeroStats();
	
	
	public readonly Dictionary<Stats, double> Bonus = ZeroStats();
	
	public readonly Dictionary<Stats, double> Initial = ZeroStats();
	
	public readonly Dictionary<Stats, double> Combat = ZeroStats();
	
	public readonly Dictionary<Stats, double> Total = ZeroStats();

	public EntityState? Parent { get; set; }

	static Dictionary<Stats, double> ZeroStats() {
		var stats = new Dictionary<Stats, double>();
		foreach (var stat in Enum.GetValues<Stats>())
		{
			stats[stat] = 0;
		}
		return stats;
	}
	
	public void ApplyModifier(StatModifier modifier) {
		if(modifier.Agent) return;
		
		var stat = modifier.Stat;
		var value = modifier.Value;
		var container = modifier.Type switch {
			StatModifiers.Base => Base,
			StatModifiers.BasePercent => BasePercent,
			StatModifiers.BaseFlat => BaseFlat,
			StatModifiers.CombatPercent => CombatPercent,
			StatModifiers.CombatFlat => CombatFlat,
			StatModifiers.Combat => CombatFlat,
			_ => throw new ArgumentOutOfRangeException()
		};
		
		container[stat] += value;
	}

	public double GetStat(StatModifiers type, Stats stat) {
		var container = type switch {
			StatModifiers.Base => Base,
			StatModifiers.BasePercent => BasePercent,
			StatModifiers.BaseFlat => BaseFlat,
			StatModifiers.CombatPercent => CombatPercent,
			StatModifiers.CombatFlat => CombatFlat,
			_ => throw new ArgumentOutOfRangeException()
		};
		var dev = container[stat];
		if(Parent != null) {
			dev += Parent.GetStat(type, stat);
		}
		
		return dev;
	}
	
	public void Reset() {
		foreach (var stat in Enum.GetValues<Stats>())
		{
			Base[stat] = 0;
			BasePercent[stat] = 0;
			BaseFlat[stat] = 0;
			CombatPercent[stat] = 0;
			CombatFlat[stat] = 0;
		}
		Update();
	}

	public void Update(bool total = true) {
		foreach (var stat in Enum.GetValues<Stats>())
		{
			
			var baseStat = GetStat(StatModifiers.Base, stat);
			var bonus = baseStat * (GetStat(StatModifiers.BasePercent, stat) / 100) + GetStat(StatModifiers.BaseFlat, stat);
			Bonus[stat] = bonus;
			Initial[stat] = bonus + baseStat;

			if (!total) continue;
			
			var initial = Initial[stat];
			var combat = initial * (GetStat(StatModifiers.CombatPercent, stat) / 100) + GetStat(StatModifiers.CombatFlat, stat);
			Combat[stat] = combat;
			Total[stat] = combat + initial;
		}
	}
}