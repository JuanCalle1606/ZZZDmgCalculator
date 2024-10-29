namespace ZZZDmgCalculator.Data.Discs;

using Models.Enum;
using Models.Info;
using static Models.Enum.BuffTrigger;
using static Models.Enum.Discs;
using static Models.Enum.Skills;
using static Models.Enum.StatModifiers;
using static Models.Enum.Stats;

[InfoData<Discs>(ChaosJazz)]
public class ChaosJazzData {
	public readonly static DiscInfo Data = new()
	{
		Id = nameof(ChaosJazz),
		StatBuff = new()
		{
			Stat = Proficiency,
			Value = 30,
			Type = BaseFlat
		},
		Buffs =
		[
			new()
			{
				Type = Permanent,
				Modifiers =
				[
					new() { Stat = FireDmg, Value = 15 },
					new() { Stat = ElectricDmg, Value = 15 },
				]
			},
			new()
			{
				SkillCondition = skill => skill.Type is Ex or Assist,
				Modifiers = new StatModifier
				{
					Stat = BonusDmg, Type = Combat, Value = 20
				}
			}
		]
	};
}