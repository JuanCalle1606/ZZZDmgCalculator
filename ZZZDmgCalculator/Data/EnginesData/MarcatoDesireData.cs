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

[InfoData<Engines>(MarcatoDesire)]
public class MarcatoDesireData {
	public readonly static EngineInfo Data = new()
	{
		Uid = MarcatoDesire,
		Icon = "Marcato_Desire",
		Rank = ItemRank.A,
		Type = Attack,
		MainStat = new()
		{
			Stat = Atk
		},
		MainStats = Templates["GameBall.Main"],
		SubStat = new()
		{
			Stat = CritRate
		},
		SubStats = Templates["Mark1.Sub"],
		Passives =
		[
			new()
			{
				Scales = [Templates["Blossom.Buff"]],
				Type = Switch,
				Modifiers = new StatModifier
				{
					Stat = Atk,
					Type = CombatPercent
				}
			},
			new()
			{
				Scales = [Templates["Blossom.Buff"]],
				Type = Switch,
				Modifiers = new StatModifier
				{
					Stat = Atk,
					Type = CombatPercent
				}
			},
		]
	};
}