namespace ZZZDmgCalculator.Data.Engines;

using Models.Enum;
using Models.Info;

[InfoData<Engines>(Engines.Gemini)]
public class GeminiData {
	public readonly static EngineInfo Data = new()
	{
		Id = nameof(Engines.Gemini),
		Icon = "Weeping_Gemini",
		Rank = ItemRank.A,
		Type = Specialties.Anomaly,
		MainStat = new()
		{
			Stat = Stats.Atk
		},
		MainStats = EngineScales.Templates["GameBall.Main"],
		SubStat = new()
		{
			Stat = Stats.Atk,
			Type = StatModifiers.BasePercent
		},
		SubStats = EngineScales.Templates["SliceOfTime.Sub"],
		Passives =
		[
			new()
			{
				Scales = [EngineScales.Templates["Gemini.Buff"]],
				Type = BuffTrigger.Stack,
				Stacks = 4,
				Modifiers = new StatModifier
				{
					Stat = Stats.Proficiency,
					Type = StatModifiers.CombatFlat
				}
			}
		]
	};
}