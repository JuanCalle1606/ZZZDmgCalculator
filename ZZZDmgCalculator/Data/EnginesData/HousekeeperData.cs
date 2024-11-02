namespace ZZZDmgCalculator.Data.EnginesData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;


[InfoData<Engines>(Engines.Housekeeper)]
public class HousekeeperData {
	public readonly static EngineInfo Data = new()
	{
		Uid = Engines.Housekeeper,
		Icon = "Housekeeper",
		Rank = ItemRank.A,
		Type = Specialties.Attack,
		MainStat = new()
		{
			Stat = Stats.Atk
		},
		MainStats = EngineScales.Templates["TheVault.Main"],
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
				Scales = [EngineScales.Templates["Housekeeper.Buff"]],
				Modifiers = new StatModifier
				{
					Stat = Stats.EnergyRegen,
					Type = StatModifiers.CombatFlat
				}
			},

			new()
			{
				Scales = [EngineScales.Templates["Housekeeper.Buff1"]],
				Type = BuffTrigger.Stack,
				Stacks = 15,
				Modifiers = new StatModifier
				{
					Stat = Stats.PhysicalDmg,
					Type = StatModifiers.Combat
				}
			}
		]
	};
}