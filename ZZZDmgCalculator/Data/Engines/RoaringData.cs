namespace ZZZDmgCalculator.Data.Engines;

using Models.Enum;
using Models.Info;

[InfoData<Engines>(Engines.Roaring)]
public class RoaringData {
	public readonly static EngineInfo Data = new()
	{
		Id = nameof(Engines.Roaring),
		Icon = "Roaring_Ride",
		Rank = ItemRank.A,
		Type = Specialties.Anomaly,
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
				Scales = [EngineScales.Templates["Transmorpher.Buff"]],
				Modifiers = new StatModifier
				{
					Stat = Stats.Atk,
					Type = StatModifiers.CombatPercent
				}
			},

			new()
			{
				Scales = [EngineScales.Templates["Roaring.Buff"]],
				Modifiers = new StatModifier
				{
					Stat = Stats.Proficiency,
					Type = StatModifiers.CombatFlat
				}
			},

			new()
			{
				Scales = [EngineScales.Templates["Bravo.Buff"]],
				Modifiers = new StatModifier
				{
					Stat = Stats.Mastery,
					Type = StatModifiers.CombatPercent
				}
			}
		]
	};
}