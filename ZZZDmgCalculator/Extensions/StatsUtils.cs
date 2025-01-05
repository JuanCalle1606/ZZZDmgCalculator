namespace ZZZDmgCalculator.Extensions;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;
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

	public static AgentStats ToAgentStats(this Stats stat, bool percent = false) => stat switch
	{
		Atk => percent ? AgentStats.AtkPercent : AgentStats.Atk,
		Hp => percent ? AgentStats.HpPercent : AgentStats.Hp,
		Def => percent ? AgentStats.DefPercent : AgentStats.Def,
		Impact => AgentStats.CritRate,
		CritRate => AgentStats.CritRate,
		CritDmg => AgentStats.CritDmg,
		PenRatio => AgentStats.PenRatio,
		Pen => AgentStats.Pen,
		EnergyRegen => AgentStats.EnergyRegen,
		Proficiency => AgentStats.AnomalyProficiency,
		Mastery => AgentStats.AnomalyMastery,
		ElectricDmg => AgentStats.ElectricDmg,
		EtherDmg => AgentStats.EtherDmg,
		FireDmg => AgentStats.FireDmg,
		IceDmg => AgentStats.IceDmg,
		PhysicalDmg => AgentStats.PhysicalDmg,
		_ => throw new ArgumentOutOfRangeException(nameof(stat), stat, null)
	};
	
	public static Stats ToStats(this AgentStats stat) => stat switch
	{
		AgentStats.Atk => Atk,
		AgentStats.AtkPercent => Atk,
		AgentStats.Hp => Hp,
		AgentStats.HpPercent => Hp,
		AgentStats.Def => Def,
		AgentStats.DefPercent => Def,
		AgentStats.CritRate => CritRate,
		AgentStats.CritDmg => CritDmg,
		AgentStats.PenRatio => PenRatio,
		AgentStats.Pen => Pen,
		AgentStats.EnergyRegen => EnergyRegen,
		AgentStats.AnomalyProficiency => Proficiency,
		AgentStats.AnomalyMastery => Mastery,
		AgentStats.ElectricDmg => ElectricDmg,
		AgentStats.EtherDmg => EtherDmg,
		AgentStats.FireDmg => FireDmg,
		AgentStats.IceDmg => IceDmg,
		AgentStats.PhysicalDmg => PhysicalDmg,
		_ => throw new ArgumentOutOfRangeException(nameof(stat), stat, null)
	};
}