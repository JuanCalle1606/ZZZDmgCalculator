namespace ZZZDmgCalculator.Data.DiscsData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;
using static Models.Enum.StatModifiers;
using static Models.Enum.Stats;
using static ZZZ.ApiModels.Skills;

[InfoData<Discs>(Discs.PolarMetal)]
public class PolarMetalData {
	public readonly static DiscInfo Data = new ()
	{
		Uid = Discs.PolarMetal,
		StatBuff = new ()
		{
			Stat = IceDmg,
			Value = 10
		},
		Buffs =
		[
			new ()
			{
				Type = BuffTrigger.Permanent,
				Modifiers =
				[
					new() { Stat = BasicDmg, Type = Combat, Value = 20 },
					new() { Stat = DashDmg, Type = Combat, Value = 20 }
				]
			},

			new ()
			{
				Modifiers =
				[
					new() { Stat = BasicDmg, Type = Combat, Value = 20 },
					new() { Stat = DashDmg, Type = Combat, Value = 20 }
				]
			}
		]
	};
}