namespace ZZZDmgCalculator.Data.DiscsData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;

[InfoData<Discs>(Discs.InfernoMetal)]
public class InfernoMetalData {
	public readonly static DiscInfo Data = new()
	{
		Uid = Discs.InfernoMetal,
		StatBuff = new()
		{
			Stat = Stats.FireDmg,
			Value = 10
		},
		Buffs = new BuffInfo()
		{
			Modifiers = new StatModifier
			{
				Stat = Stats.CritRate,
				Value = 28,
				Type = StatModifiers.Combat
			}
		}
	};
}