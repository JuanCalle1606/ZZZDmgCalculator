namespace ZZZDmgCalculator.Data.EnginesData.Stun.B;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;

[InfoData<Engines>(Engines.Hatchet)]
public class HatchetData {
	public readonly static EngineInfo Data = new()
	{
		Uid = Engines.Hatchet,
		Icon = "(Vortex)_Hatchet",
		Rank = ItemRank.B,
		Type = Specialties.Stun,  
		MainStat = new()
		{
			Stat = Stats.Atk
		},
		MainStats = EngineScales.Templates["Mark1.Main"],
		SubStat = new()
		{
			Stat = Stats.EnergyRegen,
			Type = StatModifiers.BasePercent
		},
		SubStats = EngineScales.Templates["Mark2.Sub"],
		Passives =
		[
			new()
			{
				Scales = [EngineScales.Templates["Harchet.Buff"]],
				Modifiers = new StatModifier
				{
					Stat = Stats.Impact,
					Type = StatModifiers.CombatPercent
				}
			}
		]
	};
}