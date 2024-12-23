namespace ZZZDmgCalculator.Data.Engines;

using Models.Enum;
using Models.Info;
using static Models.Enum.Skills;

[InfoData<Engines>(Engines.Superstar)]
public class SuperstarData {
	public readonly static EngineInfo Data = new()
	{
		Id = nameof(Engines.Superstar),
		Icon = "Street_Superstar",
		Rank = ItemRank.A,
		Type = Specialties.Attack,
		MainStat = new()
		{
			Stat = Stats.Atk
		},
		MainStats = EngineScales.Templates["GameBall.Main"],
		SubStat = new()
		{
			Stat = Stats.Atk,
			Type = StatModifiers.BasePercent
		},
		SubStats = EngineScales.Templates["SliceOfTime.Sub"],
		Passives =
		[
			new()
			{
				Scales = [EngineScales.Templates["Superstar.Buff"]],
				Type = BuffTrigger.Stack,
				Stacks = 3,
				SkillCondition = skill => skill.Type is Ultimate,
				Modifiers = new StatModifier
				{
					Stat = Stats.BonusDmg, Type = StatModifiers.Combat
				}
			}
		]
	};
}