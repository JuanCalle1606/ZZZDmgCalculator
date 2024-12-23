namespace ZZZDmgCalculator.Data.Engines;

using Models.Enum;
using Models.Info;

[InfoData<Engines>(Engines.Compiler)]
public class CompilerData {
	public readonly static EngineInfo Data = new()
	{
		Id = nameof(Engines.Compiler),
		Icon = "Fusion_Compiler",
		Rank = ItemRank.S,
		Type = Specialties.Anomaly,
		MainStat = new()
		{
			Stat = Stats.Atk
		},
		MainStats = EngineScales.Templates["Cradle.Main"],
		SubStat = new()
		{
			Stat = Stats.PenRatio
		},
		SubStats = EngineScales.Templates["Cradle.Sub"],
		Passives =
		[
			new()
			{
				Scales = [EngineScales.Templates["Stinger.Buff"]],
				Type = BuffTrigger.Permanent,
				Modifiers = new StatModifier
				{
					Stat = Stats.Atk,
					Type = StatModifiers.CombatPercent
				}
			},

			new()
			{
				Scales = [EngineScales.Templates["Compiler.Buff"]],
				Type = BuffTrigger.Stack,
				Stacks = 3,
				Modifiers = new StatModifier
				{
					Stat = Stats.Proficiency,
					Type = StatModifiers.CombatFlat
				}
			}
		]
	};
}