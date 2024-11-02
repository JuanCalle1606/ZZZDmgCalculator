namespace ZZZDmgCalculator.Data.EnginesData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;


[InfoData<Engines>(Engines.GameBall)]
public class GameBallData {
	public readonly static EngineInfo Data = new()
	{
		Uid = Engines.GameBall,
		Icon = "Unfettered_Game_Ball",
		Rank = ItemRank.A,
		Type = Specialties.Support,
		MainStat = new()
		{
			Stat = Stats.Atk
		},
		MainStats = EngineScales.Templates["GameBall.Main"],
		SubStat = new()
		{
			Stat = Stats.EnergyRegen,
			Type = StatModifiers.BasePercent
		},
		SubStats = EngineScales.Templates["GameBall.Sub"],
		Passives =
		[
			new()
			{
				Scales = [EngineScales.Templates["GameBall.Buff"]],
				Modifiers = new StatModifier
				{
					Stat = Stats.CritRate,
					Shared = true,
					Type = StatModifiers.Combat
				}
			}
		]
	};
}