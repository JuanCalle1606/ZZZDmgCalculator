namespace ZZZDmgCalculator.Data.EnginesData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;


[InfoData<Engines>(Engines.Cradle)]
public class CradleData {
	public readonly static EngineInfo Data = new()
	{
		Uid = Engines.Cradle,
		Icon = "Weeping_Cradle",
		Rank = ItemRank.S,
		Type = Specialties.Support,
		MainStat = new()
		{
			Stat = Stats.Atk
		},
		MainStats = EngineScales.Templates["Cradle.Main"],
		SubStat = new()
		{
			Stat = Stats.PenRatio
		},
		SubStats = EngineScales.Templates["Cradle.Sub"],
		Passives =
		[
			new()
			{
				Scales = [EngineScales.Templates["Cradle.Buff"]],
				Modifiers = new StatModifier
				{
					Stat = Stats.EnergyRegen,
					Type = StatModifiers.CombatFlat
				}
			},

			new()
			{
				Scales = [EngineScales.Templates["Cradle.Buff2"]],
				Modifiers = new StatModifier
				{
					Stat = Stats.BonusDmg,
					Shared = true,
					Type = StatModifiers.Combat
				}
			},

			new()
			{
				Scales = [EngineScales.Templates["Cradle.Buff3"]],
				Depends = 1,
				Type = BuffTrigger.Stack,
				Stacks = 6,
				Modifiers = new StatModifier
				{
					Stat = Stats.BonusDmg,
					Shared = true,
					Type = StatModifiers.Combat
				}
			}
		]
	};
}