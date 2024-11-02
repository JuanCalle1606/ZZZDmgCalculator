namespace ZZZDmgCalculator.Data.EnginesData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;


[InfoData<Engines>(Engines.Alpha)]
public class AlphaData {
	public readonly static EngineInfo Data = new()
	{
		Id = nameof(Engines.Alpha),
		Icon = "(Magnetic_Storm)_Alpha",
		Rank = ItemRank.B,
		Type = Specialties.Anomaly,
		MainStat = new()
		{
			Stat = Stats.Atk
		},
		MainStats = EngineScales.Templates["Mark1.Main"],
		SubStat = new()
		{
			Stat = Stats.Atk,
			Type = StatModifiers.BasePercent
		},
		SubStats = EngineScales.Templates["Mark1.Sub"],
		Passives =
		[
			new()
			{
				Scales = [EngineScales.Templates["Bravo.Buff"]],
				Modifiers = new StatModifier
				{
					Stat = Stats.Mastery,
					Type = StatModifiers.CombatFlat
				}
			}
		]
	};
}