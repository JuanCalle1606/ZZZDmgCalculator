namespace ZZZDmgCalculator.Data.EnginesData;

using Models.Info;
using ZZZ.ApiModels;
using static EngineScales;
using static Models.Enum.BuffTrigger;
using static Models.Enum.Specialties;
using static Models.Enum.StatModifiers;
using static Models.Enum.Stats;
using static ZZZ.ApiModels.Engines;

[InfoData<Engines>(Timeweaver)]
public class TimeweaverData {
	public readonly static EngineInfo Data = new()
	{
		Uid = Timeweaver,
		Icon = "Timeweaver",
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
				Scales = [Templates["Timeweaver.Buff"]],
				Type = Permanent,
				Modifiers = new StatModifier
				{
					Stat = BuildUp, Type = Combat
				}
			},
			new()
			{ 
				Scales = [Templates["Timeweaver.Buff1"]],
				Type = Switch,
				Modifiers = new StatModifier
				{
					Stat = Proficiency, Type = CombatFlat
				}
			},
			new()
			{ 
				Scales = [Templates["Timeweaver.Buff2"]],
				Type = Switch, // TODO: replace with stat condition, require 375 proficiency
				Modifiers = new StatModifier
				{
					Stat = BonusDmg, Type = Combat // TODO: apply only to disorder
				}
			}
		]
	};
}