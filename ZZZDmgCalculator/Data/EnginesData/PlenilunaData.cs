namespace ZZZDmgCalculator.Data.EnginesData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;
using static ZZZ.ApiModels.Skills;


[InfoData<Engines>(Engines.Pleniluna)]
public class PlenilunaData {
	public readonly static EngineInfo Data = new()
	{
		Id = nameof(Engines.Pleniluna),
		Icon = "(Lunar)_Pleniluna",
		Rank = ItemRank.B,
		Type = Specialties.Attack,
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
		Passives =
		[
			new()
			{
				Scales = [EngineScales.Templates["Pleniluna.Buff"]],
				Type = BuffTrigger.Permanent,
				SkillCondition = skill=> skill.Type is Basic or Dash or Dodge,
				Modifiers = new StatModifier
				{
					Stat = Stats.BonusDmg, Type = StatModifiers.Combat
				}
			}
		]
	};
}