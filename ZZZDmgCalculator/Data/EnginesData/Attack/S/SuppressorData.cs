namespace ZZZDmgCalculator.Data.EnginesData.Attack.S;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;

[InfoData<Engines>(Engines.Suppressor)]
public class SuppressorData {
	public readonly static EngineInfo Data = new()
	{
		Uid = Engines.Suppressor,
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
				SkillCondition = skill => skill.DmgType is Attributes.Ether,
				Modifiers = new StatModifier
				{
					Stat = Stats.BasicDmg, Type = StatModifiers.Combat
				}
			}
		]
	};
}