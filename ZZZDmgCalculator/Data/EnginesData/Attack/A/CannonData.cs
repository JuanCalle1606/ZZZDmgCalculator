namespace ZZZDmgCalculator.Data.EnginesData.Attack.A;

using Models.Info;
using ZZZ.ApiModels;
using static EngineScales;
using static Models.Enum.BuffTrigger;
using static Models.Enum.Specialties;
using static Models.Enum.StatModifiers;
using static Models.Enum.Stats;
using static ZZZ.ApiModels.Engines;
using static ZZZ.ApiModels.ItemRank;

[InfoData<Engines>(Cannon)]
public class CannonData {
	public readonly static EngineInfo Data = new()
	{
		Uid = Cannon,
		Icon = "Cannon_Rotor",
		Rank = A,
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
				Type = Permanent,
				Scales = [Templates["Cannon.Buff"]],
				Modifiers = new StatModifier
				{
					Stat = Atk,
					Type = CombatPercent
				}
			}
		],
		Skill = new()
		{
			Engine = true,
			Value = 200
		}
	};
}