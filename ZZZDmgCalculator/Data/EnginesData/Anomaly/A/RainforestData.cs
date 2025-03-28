namespace ZZZDmgCalculator.Data.EnginesData.Anomaly.A;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;

[InfoData<Engines>(Engines.Rainforest)]
public class RainforestData {
	public readonly static EngineInfo Data = new()
	{
		Uid = Engines.Rainforest,
		Icon = "Rainforest_Gourmet",
		Rank = ItemRank.A,
		Type = Specialties.Anomaly,
		MainStat = new()
		{
			Stat = Stats.Atk
		},
		MainStats = EngineScales.Templates["GameBall.Main"],
		SubStat = new()
		{
			Stat = Stats.Proficiency,
			Type = StatModifiers.BaseFlat
		},
		SubStats = EngineScales.Templates["Rainforest.Sub"],
		Passives =
		[
			new()
			{
				Scales = [EngineScales.Templates["Kaboom.Buff"]],
				Type = BuffTrigger.Stack,
				Stacks = 10,
				Modifiers = new StatModifier
				{
					Stat = Stats.Atk,
					Type = StatModifiers.CombatPercent
				}
			}
		]
	};
}