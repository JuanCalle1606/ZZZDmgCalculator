namespace ZZZDmgCalculator.Data.DiscsData;

using Models.Info;
using ZZZ.ApiModels;
using static Models.Enum.BuffTrigger;
using static Models.Enum.StatModifiers;
using static ZZZ.ApiModels.Discs;
using static Models.Enum.Stats;

[UrlTemplate("icons/discs/Drive_Disc_{Id_}_S.webp")]
[InfoData<Discs>(ChaoticMetal)]
public class ChaoticMetalData {
	public readonly static DiscInfo Data = new()
	{
		Uid = ChaoticMetal,
		StatBuff = new()
		{
			Stat = EtherDmg,
			Value = 10
		},
		Buffs =[
			new BuffInfo
			{
				Type = Permanent,
				Modifiers = new StatModifier
				{
					Stat = CritDmg,
					Type = Combat,
					Value = 20
				}
			},
			new BuffInfo
			{
				Type = Stack,
				Stacks = 6,
				Modifiers = new StatModifier
				{
					Stat = CritDmg,
					Type = Combat,
					Value = 5.5
				}
			}
		]
	};
}