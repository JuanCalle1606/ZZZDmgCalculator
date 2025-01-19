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
				Type = Permanent,
				Modifiers = new StatModifier
				{
					Stat = CritDmg, Value = 30, Type = Combat
				},
				StatRequirements = new StatRequirement
				{
					Stat = Mastery, Value = 115
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