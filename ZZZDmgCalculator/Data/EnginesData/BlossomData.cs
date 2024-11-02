namespace ZZZDmgCalculator.Data.EnginesData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;
using static ZZZ.ApiModels.Skills;


[InfoData<Engines>(Engines.Blossom)]
public class BlossomData {
	public readonly static EngineInfo Data = new()
	{
		Id = nameof(Engines.Blossom),
		Icon = "Gilded_Blossom",
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
				Scales = [EngineScales.Templates["Blossom.Buff"]],
				Type = BuffTrigger.Permanent,
				Modifiers = new StatModifier
				{
					Stat = Stats.Atk,
					Type = StatModifiers.CombatPercent
				}
			},

			new()
			{
				Scales = [EngineScales.Templates["Superstar.Buff"]],
				Type = BuffTrigger.Permanent,
				SkillCondition = skill => skill.Type is Ex,
				Modifiers = new StatModifier
				{
					Stat = Stats.BonusDmg, Type = StatModifiers.Combat
				}
			}
		]
	};
}