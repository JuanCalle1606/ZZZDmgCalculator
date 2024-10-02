namespace ZZZDmgCalculator.Data.Engines;

using Models.Enum;
using Models.Info;
using static Models.Enum.Skills;

[InfoData<Engines>(Engines.Drill)]
public class DrillData {
	public readonly static EngineInfo Data = new()
	{
		Id = nameof(Engines.Drill),
		Icon = "Drill_Rig_-_Red_Axis",
		Rank = ItemRank.A,
		Type = Specialties.Attack,
		MainStat = new()
		{
			Stat = Stats.Atk
		},
		MainStats = EngineScales.Templates["TheVault.Main"],
		SubStat = new()
		{
			Stat = Stats.EnergyRegen,
			Type = StatModifiers.BasePercent
		},
		SubStats = EngineScales.Templates["GameBall.Sub"],
		Passives =
		[
			new()
			{
				Scales = [EngineScales.Templates["Drill.Buff"]],
				SkillCondition = skill => skill.Type is Basic or Dash,
				Modifiers = new StatModifier
				{
					Stat = Stats.ElectricDmg,
					Type = StatModifiers.Combat
				}
			}
		]
	};
}