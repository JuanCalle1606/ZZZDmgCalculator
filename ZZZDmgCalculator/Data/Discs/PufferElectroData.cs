namespace ZZZDmgCalculator.Data.Discs;

using Models.Enum;
using Models.Info;
using static Models.Enum.Skills;

[InfoData<Discs>(Discs.PufferElectro)]
public class PufferElectroData {
	public readonly static DiscInfo Data = new ()
	{
		Id = nameof(Discs.PufferElectro),
		StatBuff = new ()
		{
			Stat = Stats.PenRatio,
			Value = 10
		},
		Buffs =
		[
			new ()
			{
				Type = BuffTrigger.Permanent,
				SkillCondition = skill => skill.Type is Ultimate,
				Modifiers = new StatModifier
				{
					Stat = Stats.BonusDmg, Type = StatModifiers.Combat,
					Value = 20
				}
			},

			new ()
			{
				Modifiers = new StatModifier
				{
					Stat = Stats.Atk,
					Value = 15,
					Type = StatModifiers.CombatPercent
				}
			}
		]
	};
}