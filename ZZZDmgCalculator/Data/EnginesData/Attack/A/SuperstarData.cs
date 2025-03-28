namespace ZZZDmgCalculator.Data.EnginesData.Attack.A;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;

[InfoData<Engines>(Engines.Superstar)]
public class SuperstarData {
	public readonly static EngineInfo Data = new()
	{
		Uid = Engines.Superstar,
		Icon = "Street_Superstar",
		Rank = ItemRank.A,
		Type = Specialties.Attack,
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
				Scales = [EngineScales.Templates["Superstar.Buff"]],
				Type = BuffTrigger.Stack,
				Stacks = 3,
				Modifiers = new StatModifier
				{
					Stat = Stats.UltimateDmg, Type = StatModifiers.Combat
				}
			}
		]
	};
}