namespace ZZZDmgCalculator.Data.Engines;

using Models.Enum;
using Models.Info;
using static EngineScales;
using static Models.Enum.BuffTrigger;
using static Models.Enum.Engines;
using static Models.Enum.ItemRank;
using static Models.Enum.Specialties;
using static Models.Enum.StatModifiers;
using static Models.Enum.Stats;

[InfoData<Engines>(TuskOfFury)]
public class TuskOfFuryData {
	public readonly static EngineInfo Data = new()
	{
		Id = nameof(TuskOfFury),
		Icon = "Tusks_of_Fury",
		Rank = S,
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
			{
				Scales = [Templates["TuskOfFury.Buff1"]],
				Modifiers = new StatModifier
				{
					Stat = BonusDmg
				}
			}
		]
	};
}