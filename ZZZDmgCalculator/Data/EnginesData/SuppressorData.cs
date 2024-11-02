namespace ZZZDmgCalculator.Data.EnginesData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;
using static ZZZ.ApiModels.Skills;


[InfoData<Engines>(Engines.Suppressor)]
public class SuppressorData {
	public readonly static EngineInfo Data = new()
	{
		Id = nameof(Engines.Suppressor),
		Icon = "Riot_Suppressor_Mark_VI",
		Rank = ItemRank.S,
		Type = Specialties.Attack,
		MainStat = new()
		{
			Stat = Stats.Atk
		},
		MainStats = EngineScales.Templates["Stinger.Main"],
		SubStat = new()
		{
			Stat = Stats.CritDmg
		},
		SubStats = EngineScales.Templates["Suppressor.Sub"],
		Passives =
		[
			new()
			{
				Scales = [EngineScales.Templates["Suppressor.Buff"]],
				Type = BuffTrigger.Permanent,
				Modifiers = new StatModifier
				{
					Stat = Stats.CritRate,
					Type = StatModifiers.Combat
				}
			},

			new()
			{
				Scales = [EngineScales.Templates["Suppressor.Buff1"]],
				SkillCondition = skill => skill.Type is Basic && skill.DmgType is Attributes.Ether,
				Modifiers = new StatModifier
				{
					Stat = Stats.BonusDmg, Type = StatModifiers.Combat
				}
			}
		]
	};
}