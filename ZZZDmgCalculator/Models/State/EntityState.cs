namespace ZZZDmgCalculator.Models.State;

using Enum;
using Enum=System.Enum;

/**
 * Holds the stats of an entity
 */
public class EntityState {

	/**
	 * Base stats of the entity, normally only affected by level, core skill and engines.
	 */
	public Dictionary<Stats, double> Base;

	/**
	 * Stats from <see cref="Base"/> after apply <see cref="StatModifiers.BaseFlat"/> and <see cref="StatModifiers.BasePercent"/> modifiers.
	 */
	public Dictionary<Stats, double> Bonus;
	
	/**
	 * Stats from <see cref="Bonus"/> after apply <see cref="StatModifiers.Combat"/> modifiers.
	 */
	public Dictionary<Stats, double> Initial;

	/**
	 * Stats from <see cref="Bonus"/> after apply <see cref="StatModifiers.Combat"/> modifiers.
	 */
	public Dictionary<Stats, double> Combat;

	/**
	 * Total Stats of the entity, sum of <see cref="Base"/>, <see cref="Bonus"/> and <see cref="Combat"/>.
	 */
	public Dictionary<Stats, double> Total;
	
	public EntityState() {
		Base = CeroStats();
		Bonus = CeroStats();
		Combat = CeroStats();
		Initial = CeroStats();
		Total = CeroStats();
	}

	public static Dictionary<Stats, double> CeroStats() {
		var stats = new Dictionary<Stats, double>();
		foreach (var stat in Enum.GetValues<Stats>())
		{
			stats[stat] = 0;
		}
		return stats;
	}

	public void Update(bool b = true) {
		foreach (var stat in Enum.GetValues<Stats>())
		{
			Initial[stat] = Base[stat] + Bonus[stat];
			if(b) Total[stat] = Initial[stat] + Combat[stat];
		}
	}
}