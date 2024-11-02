namespace ZZZDmgCalculator.Extensions;

using Models.Enum;
using Models.Info;
using static Models.Enum.Stats;

public static class StatsUtils {

	public static string Format(this Stats stat, double value) {
		var percent = stat is >= CritRate and <= PenRatio or >= ElectricDmg;
		if (stat == EnergyRegen)
		{
			return $"{value:0.0#}";
		}
		return percent ? $"{value:0.#}%" : $"{value:N0}";
	}
	
	public static string Format(this StatModifier stat, int buffValueMultiplier = 1, double valuePerStack = 0, bool abs = false) {
		var value = buffValueMultiplier == 0 ? valuePerStack : stat.Value / buffValueMultiplier;
		if (abs) value = Math.Abs(value);
		var percent = stat.IsPercent;
		if (stat.Stat == EnergyRegen && !percent)
		{
			return $"{value:0.0#}";
		}
		return percent ? $"{value:0.#}%" : $"{value:N0}";
	}
}