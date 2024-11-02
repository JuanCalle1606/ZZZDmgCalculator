namespace ZZZDmgCalculator.Data.DiscsData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;
using static ZZZ.ApiModels.Skills;

[InfoData<Discs>(Discs.PolarMetal)]
public class PolarMetalData {
	public readonly static DiscInfo Data = new ()
	{
		Id = nameof(Discs.PolarMetal),
		StatBuff = new ()
		{
			Stat = Stats.IceDmg,
			Value = 10
		},
		Buffs =
		[
			new ()
			{
				Type = BuffTrigger.Permanent,
				SkillCondition = skill => skill.Type is Basic or Dash,
				Modifiers = new StatModifier
				{
					Stat = Stats.BonusDmg, Type = StatModifiers.Combat,
					Value = 28
				}
			},

			new ()
			{
				SkillCondition = skill => skill.Type is Basic or Dash,
				Modifiers = new StatModifier
				{
					Stat = Stats.BonusDmg, Type = StatModifiers.Combat,
					Value = 28
				}
			}
		]
	};
}