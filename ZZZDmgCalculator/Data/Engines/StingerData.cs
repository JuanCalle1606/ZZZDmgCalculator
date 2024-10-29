namespace ZZZDmgCalculator.Data.Engines;

using Models.Enum;
using Models.Info;

[InfoData<Engines>(Engines.Stinger)]
public class StingerData {
	public readonly static EngineInfo Data = new()
	{
		Id = nameof(Engines.Stinger),
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
			{ // TODO: Change to Buildup Rate when implemented
				Scales = [EngineScales.Templates["Stinger.Buff1"]],
				Type = BuffTrigger.Permanent,
				Depends = 0,
				RequiredStacks = 3,
				Modifiers = new StatModifier
				{
					Stat = Stats.Mastery,
					Type = StatModifiers.CombatPercent
				}
			}
		]
	};
}