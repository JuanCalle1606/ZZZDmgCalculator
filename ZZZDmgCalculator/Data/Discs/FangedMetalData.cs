namespace ZZZDmgCalculator.Data.Discs;

using Models.Enum;
using Models.Info;

[InfoData<Discs>(Discs.FangedMetal)]
public class FangedMetalData {
	public readonly static DiscInfo Data = new()
	{
		Id = nameof(Discs.FangedMetal),
		StatBuff = new()
		{
			Stat = Stats.PhysicalDmg,
			Value = 10
		},
		// I don't know if the full set is a bonus damage buff for agent or a dmg taken debuff for enemy.
		// I am assuming it is a dmg buff, but it needs more deep testing.
		Buffs = new BuffInfo()
		{
			Modifiers = new StatModifier
			{
				Stat = Stats.BonusDmg,
				Value = 35
			}
		}
	};
}