namespace ZZZDmgCalculator.Data.EnginesData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;


[InfoData<Engines>(Engines.Cushion)]
public class CushionData {
	public readonly static EngineInfo Data = new()
	{
		Uid = Engines.Cushion,
		Icon = "Steel_Cushion",
		Rank = ItemRank.S,
		Type = Specialties.Attack,
		MainStat = new()
		{
			Stat = Stats.Atk
		},
		MainStats = EngineScales.Templates["Cradle.Main"],
		SubStat = new()
		{
			Stat = Stats.CritRate
		},
		SubStats = EngineScales.Templates["Cradle.Sub"],
		Passives =
		[
			new()
			{
				Scales = [EngineScales.Templates["Cushion.Buff"]],
				Type = BuffTrigger.Permanent,
				Modifiers = new StatModifier
				{
					Stat = Stats.PhysicalDmg,
					Type = StatModifiers.Combat
				}
			},

			new()
			{
				Scales = [EngineScales.Templates["Cushion.Buff1"]],
				Modifiers = new StatModifier
				{
					Stat = Stats.BonusDmg, Type = StatModifiers.Combat
				}
			}
		]
	};
}