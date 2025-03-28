namespace ZZZDmgCalculator.Data.EnginesData;

using Models.Info;
using ZZZ.ApiModels;
using static EngineScales;
using static Models.Enum.BuffTrigger;
using static Models.Enum.Specialties;
using static Models.Enum.StatModifiers;
using static Models.Enum.Stats;
using static ZZZ.ApiModels.Engines;
using static ZZZ.ApiModels.Skills;

[InfoData<Engines>(ZanshinHerbCase)]
public class ZanshinHerbCaseData {
	public readonly static EngineInfo Data = new()
	{
		Uid = ZanshinHerbCase,
		Icon = "Zanshin_Herb_Case",
		Rank = ItemRank.S,
		Type = Attack,
		MainStat = new()
		{
			Stat = Atk
		},
		MainStats = Templates["Stinger.Main"],
		SubStat = new()
		{
			Stat = CritDmg
		},
		SubStats = Templates["Suppressor.Sub"],
		Passives = [
			new()
			{
				Scales = [Templates["Spring.Buff1"]],
				Type = Permanent,
				Modifiers = new StatModifier
				{
					Stat = CritRate,
					Type = Combat
				}
			},
			new()
			{
				Scales = [Templates["Roaring.Buff"]],
				Type = Permanent,
				SkillCondition = s=> s.Type is Dash,
				Modifiers = new StatModifier
				{
					Stat = ElectricDmg,
					Type = Combat
				}
			},
			new()
			{
				Scales = [Templates["Spring.Buff1"]],
				Type = Switch,
				Modifiers = new StatModifier
				{
					Stat = CritRate,
					Type = Combat
				}
			},
		]
	};
}