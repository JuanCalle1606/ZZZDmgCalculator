namespace ZZZDmgCalculator.Util;

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
		return !percent ? $"{value:N0}" : $"{value:N1}%";
	}
	
	public static string Format(this StatModifier stat) {
		var value = stat.Value;
		var percent = stat.IsPercent;
		if (stat.Stat == EnergyRegen)
		{
			return $"{value:0.0#}";
		}
		return !percent ? $"{value:N0}" : $"{value:N1}%";
	}
}