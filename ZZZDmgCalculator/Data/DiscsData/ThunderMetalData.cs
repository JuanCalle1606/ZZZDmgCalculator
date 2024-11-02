namespace ZZZDmgCalculator.Data.DiscsData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;

[InfoData<Discs>(Discs.ThunderMetal)]
public class ThunderMetalData {
	public readonly static DiscInfo Data = new()
	{
		Uid = Discs.ThunderMetal,
		StatBuff = new()
		{
			Stat = Stats.ElectricDmg,
			Value = 10
		},
		Buffs = new BuffInfo
		{
			Modifiers = new StatModifier
			{
				Stat = Stats.Atk,
				Value = 27,
				Type = StatModifiers.CombatPercent
			}
		}
	};
}