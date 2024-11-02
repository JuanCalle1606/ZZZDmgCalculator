namespace ZZZDmgCalculator.Data.DiscsData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;

[InfoData<Discs>(Discs.WoodpeckerElectro)]
public class WoodpeckerElectroData {
	public readonly static DiscInfo Data = new()
	{
		Uid = Discs.WoodpeckerElectro,
		StatBuff = new()
		{
			Stat = Stats.CritRate,
			Value = 8
		},
		Buffs = new BuffInfo
		{
			Type = BuffTrigger.Stack,
			Stacks = 3,
			Modifiers = new StatModifier
			{
				Stat = Stats.Atk,
				Value = 9,
				Type = StatModifiers.CombatPercent
			}
		}
	};
}