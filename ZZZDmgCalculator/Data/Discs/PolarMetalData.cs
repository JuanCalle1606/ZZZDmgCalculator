namespace ZZZDmgCalculator.Data.Discs;

using Models.Enum;
using Models.Info;
using static Models.Enum.Skills;

[InfoData<Discs>(Discs.PolarMetal)]
public class PolarMetalData {
	public readonly static DiscInfo Data = new()
	{
		Id = nameof(Discs.PolarMetal),
		StatBuff = new()
		{
			Stat = Stats.IceDmg,
			Value = 10
		},
		FullSets =
		[
			new()
			{
				Type = BuffTrigger.Permanent,
				SkillCondition = skill => skill.Type is Basic or Dash,
				Modifiers = new StatModifier
				{
					Stat = Stats.BonusDmg,
					Value = 28
				}
			},

			new()
			{
				SkillCondition = skill => skill.Type is Basic or Dash,
				Modifiers = new StatModifier
				{
					Stat = Stats.BonusDmg,
					Value = 28
				}
			}
		]
	};
}