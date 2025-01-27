namespace ZZZDmgCalculator.Data.EnginesData;

using Models.Info;
using ZZZ.ApiModels;
using static EngineScales;
using static Models.Enum.BuffTrigger;
using static Models.Enum.Specialties;
using static Models.Enum.StatModifiers;
using static Models.Enum.Stats;
using static ZZZ.ApiModels.Engines;

[InfoData<Engines>(FlamemakerShaker)]
public class FlamemakerShakerData {
	public readonly static EngineInfo Data = new()
	{
		Uid = FlamemakerShaker,
		Icon = "Flamemaker_Shaker",
		Rank = ItemRank.S,
		Type = Anomaly,
		MainStat = new()
		{
			Stat = Atk
		},
		MainStats = Templates["Stinger.Main"],
		SubStat = new()
		{
			Stat = Atk
		},
		SubStats = Templates["Brimstone.Sub"],
		Passives =
		[
			new()
			{
				Scales = [Templates["Cradle.Buff"]],
				Type = Switch,
				Modifiers = new StatModifier
				{
					Stat = EnergyRegen, Type = CombatFlat
				}
			},
			new()
			{
				Scales = [Templates["Brimstone.Buff"]],
				Type = Stack,
				Stacks = 10,
				Modifiers = new StatModifier
				{
					Stat = BonusDmg, Type = Combat
				}
			},
			new()
			{
				Type = Switch,
				Amplify = "Buffs.Engines.FlamemakerShaker.1",
				Modifiers = new StatModifier
				{
					Stat = BonusDmg, Type = Combat, Agent = true, Value = 200
				}
			},
			new()
			{
				Scales = [Templates["Flamemaker.Buff"]],
				Type = Switch,
				RequiredStacks = 5,
				Depends = 1,
				Modifiers = new StatModifier
				{
					Stat = Proficiency, Type = CombatFlat
				}
			},
		]
	};
}