namespace ZZZDmgCalculator.Data.EnginesData.Stun.A;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;
using static Models.Enum.BuffTrigger;

[InfoData<Engines>(Engines.Shooter)]
public class ShooterData {
	public readonly static EngineInfo Data = new()
	{
		Uid = Engines.Shooter,
		Icon = "Six_Shooter",
		Rank = ItemRank.A,
		Type = Specialties.Stun,  
		MainStat = new()
		{
			Stat = Stats.Atk
		},
		MainStats = EngineScales.Templates["GameBall.Main"],
		SubStat = new()
		{
			Stat = Stats.Impact,
			Type = StatModifiers.BasePercent
		},
		SubStats = EngineScales.Templates["Shooter.Sub"],
		Passives = new BuffInfo
		{
			Type = Stack,
			Stacks = 3,
			Scales = [EngineScales.Templates["Shooter.Buff"]],
			SkillCondition = skill => skill.Type is Skills.Ex,
			Modifiers = new StatModifier
			{
				Stat = Stats.Daze,
				Type = StatModifiers.Combat,
			}
		}
	};
}