namespace ZZZDmgCalculator.Data.EnginesData.Defense.S;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;
using static EngineScales;
using static Models.Enum.BuffTrigger;
using static Models.Enum.Specialties;
using static Models.Enum.StatModifiers;
using static Models.Enum.Stats;
using static ZZZ.ApiModels.Engines;

[InfoData<Engines>(TuskOfFury)]
public class TuskOfFuryData {
	public readonly static EngineInfo Data = new()
	{
		Uid = TuskOfFury,
		Icon = "Tusks_of_Fury",
		Rank = ItemRank.S,
		Type = Defense,
		MainStat = new()
		{
			Stat = Atk
		},
		MainStats = Templates["Stinger.Main"],
		SubStat = new()
		{
			Stat = Impact, Type = BasePercent
		},
		SubStats = Templates["Teapot.Sub"],
		Passives =
		[
			new()
			{
				Scales = [Templates["TuskOfFury.Buff"]],
				Type = Permanent,
				Modifiers = new StatModifier
				{
					Stat = ShieldPower, Type = Combat
				}
			},
			new()
			{// Add daze when implemented
				Scales = [Templates["TuskOfFury.Buff1"]],
				Modifiers = new StatModifier
				{
					Stat = BonusDmg, Type = Combat
				}
			}
		]
	};
}