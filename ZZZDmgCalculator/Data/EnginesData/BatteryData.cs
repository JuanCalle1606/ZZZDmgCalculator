namespace ZZZDmgCalculator.Data.EnginesData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;


[InfoData<Engines>(Engines.Battery)]
public class BatteryData {
	public readonly static EngineInfo Data = new()
	{
		Id = nameof(Engines.Battery),
		Icon = "Demara_Battery_Mark_II",
		Rank = ItemRank.A,
		Type = Specialties.Stun,  
		MainStat = new()
		{
			Stat = Stats.Atk
		},
		MainStats = EngineScales.Templates["TheVault.Main"],
		SubStat = new()
		{
			Stat = Stats.Impact,
			Type = StatModifiers.BasePercent
		},
		SubStats = EngineScales.Templates["Shooter.Sub"],
		Passives =
		[
			new()
			{
				Scales = [EngineScales.Templates["TheVault.Buff"]],
				Type = BuffTrigger.Permanent,
				Modifiers = new StatModifier
				{
					Stat = Stats.ElectricDmg,
					Type = StatModifiers.Combat
				}
			},

			new()
			{
				Scales = [EngineScales.Templates["Battery.Buff"]],
				Modifiers = new StatModifier
				{
					Stat = Stats.EnergyRegen,
					Type = StatModifiers.CombatPercent
				}
			}
		]
	};
}