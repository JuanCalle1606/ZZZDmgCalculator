namespace ZZZDmgCalculator.Data.EnginesData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;


[InfoData<Engines>(Engines.Stinger)]
public class StingerData {
	public readonly static EngineInfo Data = new()
	{
		Uid = Engines.Stinger,
		Icon = "Sharpened_Stinger",
		Rank = ItemRank.S,
		Type = Specialties.Anomaly,
		MainStat = new()
		{
			Stat = Stats.Atk
		},
		MainStats = EngineScales.Templates["Stinger.Main"],
		SubStat = new()
		{
			Stat = Stats.Proficiency,
			Type = StatModifiers.BaseFlat
		},
		SubStats = EngineScales.Templates["Stinger.Sub"],
		Passives =
		[
			new()
			{
				Scales = [EngineScales.Templates["Stinger.Buff"]],
				Type = BuffTrigger.Stack,
				Stacks = 3,
				Modifiers = new StatModifier
				{
					Stat = Stats.PhysicalDmg,
					Type = StatModifiers.Combat
				}
			},

			new()
			{
				Scales = [EngineScales.Templates["Stinger.Buff1"]],
				Type = BuffTrigger.Permanent,
				Depends = 0,
				RequiredStacks = 3,
				Modifiers = new StatModifier
				{
					Stat = Stats.BuildUp,
					Type = StatModifiers.Combat
				}
			}
		]
	};
}