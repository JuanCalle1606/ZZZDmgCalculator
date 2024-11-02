namespace ZZZDmgCalculator.Data.DiscsData;

using Models.Info;
using ZZZ.ApiModels;
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
		Buffs = new BuffInfo()
		{
			Modifiers = new StatModifier
			{
				Stat = DmgTaken,
				Enemy = true,
				Value = 18
			}
		}
	};
}