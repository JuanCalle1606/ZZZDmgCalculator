namespace ZZZDmgCalculator.Data.EnginesData;

using Models.Info;
using ZZZ.ApiModels;
using static EngineScales;
using static Models.Enum.BuffTrigger;
using static Models.Enum.Specialties;
using static Models.Enum.StatModifiers;
using static Models.Enum.Stats;
using static ZZZ.ApiModels.Engines;

[InfoData<Engines>(HailstormShrine)]
public class HailstormShrineData {
	public readonly static EngineInfo Data = new()
	{
		Uid = HailstormShrine,
		Icon = "Hailstorm_Shrine",
		Rank = ItemRank.S,
		Type = Anomaly,
		MainStat = new()
		{
			Stat = Atk
		},
		MainStats = Templates["Hailstorm.Main"],
		SubStat = new()
		{
			Stat = CritRate
		},
		SubStats = Templates["Cradle.Sub"],
		Passives =
		[
			new()
			{
				Scales = [Templates["Hailstorm.Buff"]],
				Type = Permanent,
				Modifiers = new StatModifier
				{
					Stat = CritDmg, Type = Combat
				}
			},
			new()
			{ 
				Scales = [Templates["Base.Buff"]],
				Type = Stack,
				Stacks = 2,
				Modifiers = new StatModifier
				{
					Stat = IceDmg, Type = Combat
				}
			}
		]
	};
}