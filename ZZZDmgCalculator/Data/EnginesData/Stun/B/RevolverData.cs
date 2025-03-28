namespace ZZZDmgCalculator.Data.EnginesData.Stun.B;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;

[InfoData<Engines>(Engines.Revolver)]
public class RevolverData {
	public readonly static EngineInfo Data = new()
	{
		Uid = Engines.Revolver,
		Icon = "(Vortex)_Revolver",
		Rank = ItemRank.B,
		Type = Specialties.Stun,  
		MainStat = new()
		{
			Stat = Stats.Atk
		},
		MainStats = EngineScales.Templates["Mark1.Main"],
		SubStat = new()
		{
			Stat = Stats.Atk,
			Type = StatModifiers.BasePercent
		},
		SubStats = EngineScales.Templates["Mark1.Sub"],
		Passives = new BuffInfo()
		{
			Type = BuffTrigger.Permanent,
			Scales = [EngineScales.Templates["Spring.Buff1"]],
			SkillCondition = skill => skill.Type is Skills.Ex,
			Modifiers = new StatModifier
			{
				Stat = Stats.Daze,
				Type = StatModifiers.Combat,
			}
		}
	};
}
