namespace ZZZDmgCalculator.Data.DiscsData;

using Models.Info;
using ZZZ.ApiModels;
using static Models.Enum.BuffTrigger;
using static ZZZ.ApiModels.Discs;
using static ZZZ.ApiModels.Skills;
using static Models.Enum.StatModifiers;
using static Models.Enum.Stats;

[InfoData<Discs>(BranchBladeSong)]
public class BranchBladeSongData {
	public readonly static DiscInfo Data = new()
	{
		Uid = BranchBladeSong,
		StatBuff = new()
		{
			Stat = CritDmg,
			Value = 16
		},
		Buffs =
		[
			new()
			{
				Type = Switch,// TODO: change to permanent buff with stat condition (require 115 anomaly mastery)
				Modifiers = new StatModifier
				{
					Stat = CritDmg, Value = 30, Type = Combat
				}
			},
			new()
			{
				Modifiers = new StatModifier
				{
					Stat = CritRate, Type = Combat, Value = 12
				}
			}
		]
	};
}