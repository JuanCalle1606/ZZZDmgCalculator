namespace ZZZDmgCalculator.Data.EnginesData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;
using static EngineScales;
using static Models.Enum.BuffTrigger;
using static ZZZ.ApiModels.Engines;
using static Models.Enum.Specialties;
using static Models.Enum.StatModifiers;
using static Models.Enum.Stats;

[InfoData<Engines>(BlazingLaurel)]
public class BlazingLaurelData {
	public readonly static EngineInfo Data = new()
	{
		Uid = BlazingLaurel,
		Icon = "Blazing_Laurel",
		Rank = ItemRank.S,
		Type = Stun,
		MainStat = new()
		{
			Stat = Atk
		},
		MainStats = Templates["Stinger.Main"],
		SubStat = new()
		{
			Stat = Impact, Type = BasePercent
		},
		SubStats = Templates["Teapot.Sub"],
		Passives =
		[
			new()
			{
				Scales = [Templates["Blazing.Buff"]],
				Type = Switch,
				Modifiers = new StatModifier
				{
					Stat = Impact, Type = CombatPercent
				}
			},
			new()
			{
				Scales = [Templates["Blazing.Buff1"]],
				Type = Stack,
				Stacks = 20,
				Modifiers =
				[
					new() { Stat = FireCritDmg, Type = Combat, Shared = true },
					new() { Stat = IceCritDmg, Type = Combat, Shared = true }
				]
			}
		]
	};
}