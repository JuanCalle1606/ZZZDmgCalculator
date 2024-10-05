namespace ZZZDmgCalculator.Data.Discs;

using Models.Enum;
using Models.Info;
using Util;

[InfoData<Discs>(Discs.SwingJazz)]
public class SwingJazzData {
	public readonly static DiscInfo Data = new()
	{
		Id = nameof(Discs.SwingJazz),
		StatBuff = new()
		{
			Stat = Stats.EnergyRegen,
			Value = 20,
			Type = StatModifiers.BasePercent
		},
		Buffs = new BuffInfo
		{
			Modifiers = new StatModifier
			{
				Stat = Stats.BonusDmg,
				Value = 15
			}
		}
	};
}