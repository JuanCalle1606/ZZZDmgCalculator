namespace ZZZDmgCalculator.Data.DiscsData;

using Models.Info;
using ZZZ.ApiModels;
using static Models.Enum.BuffTrigger;
using static Models.Enum.StatModifiers;
using static Models.Enum.Stats;
using static ZZZ.ApiModels.Discs;
using static ZZZ.ApiModels.Skills;

[InfoData<Discs>(ChaosJazz)]
public class ChaosJazzData {
	public readonly static DiscInfo Data = new()
	{
		Uid = ChaosJazz,
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
				Modifiers =
				[
					new() { Stat = ExDmg, Type = Combat, Value = 20 },
					new() { Stat = AssistDmg, Type = Combat, Value = 20 }
				]
			}
		]
	};
}