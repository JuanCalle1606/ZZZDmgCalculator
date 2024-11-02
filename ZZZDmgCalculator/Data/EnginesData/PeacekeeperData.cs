namespace ZZZDmgCalculator.Data.EnginesData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;


[InfoData<Engines>(Engines.Peacekeeper)]
public class PeacekeeperData {
	public readonly static EngineInfo Data = new()
	{
		Id = nameof(Engines.Peacekeeper),
		Icon = "Peacekeeper_-_Specialized",
		Rank = ItemRank.A,
		Type = Specialties.Defense,
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
				Modifiers = new StatModifier
				{
					Stat = Stats.EnergyRegen,
					Type = StatModifiers.CombatFlat,
					Value = 0.4
				}
			}
		]
	};
}