namespace ZZZDmgCalculator.Data.EnginesData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;


[InfoData<Engines>(Engines.Hellfire)]
public class HellfireData {
	public readonly static EngineInfo Data = new()
	{
		Uid = Engines.Hellfire,
		Icon = "Hellfire_Gears",
		Rank = ItemRank.S,
		Type = Specialties.Stun,
		MainStat = new()
		{
			Stat = Stats.Atk
		},
		MainStats = EngineScales.Templates["Cradle.Main"],
		SubStat = new()
		{
			Stat = Stats.Impact,
			Type = StatModifiers.BasePercent
		},
		SubStats = EngineScales.Templates["Teapot.Sub"],
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
				Type = BuffTrigger.Stack,
				Stacks = 2,
				Modifiers = new StatModifier
				{
					Stat = Stats.Impact,
					Type = StatModifiers.CombatPercent
				}
			}
		]
	};
}