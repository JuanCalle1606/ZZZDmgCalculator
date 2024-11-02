namespace ZZZDmgCalculator.Data.EnginesData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;


[InfoData<Engines>(Engines.Cannon)]
public class CannonData {
	public readonly static EngineInfo Data = new()
	{
		Id = nameof(Engines.Cannon),
		Icon = "Cannon_Rotor",
		Rank = ItemRank.A,
		Type = Specialties.Attack,
		MainStat = new()
		{
			Stat = Stats.Atk
		},
		MainStats = EngineScales.Templates["GameBall.Main"],
		SubStat = new()
		{
			Stat = Stats.CritRate
		},
		SubStats = EngineScales.Templates["Mark1.Sub"],
		Passives =
		[
			new()
			{
				Scales = [EngineScales.Templates["Cannon.Buff"]],
				Modifiers = new StatModifier
				{
					Stat = Stats.Atk,
					Type = StatModifiers.CombatPercent
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