namespace ZZZDmgCalculator.Data.EnginesData.Anomaly.B;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;

[InfoData<Engines>(Engines.Bravo)]
public class BravoData {
	public readonly static EngineInfo Data = new()
	{
		Uid = Engines.Bravo,
		Icon = "(Magnetic_Storm)_Bravo",
		Rank = ItemRank.B,
		Type = Specialties.Anomaly,
		MainStat = new()
		{
			Stat = Stats.Atk
		},
		MainStats = EngineScales.Templates["Mark1.Main"],
		SubStat = new()
		{
			Stat = Stats.Proficiency,
			Type = StatModifiers.BaseFlat
		},
		SubStats = EngineScales.Templates["Bravo.Sub"],
		Passives =
		[
			new()
			{
				Scales = [EngineScales.Templates["Bravo.Buff"]],
				Modifiers = new StatModifier
				{
					Stat = Stats.Proficiency,
					Type = StatModifiers.CombatFlat
				}
			}
		]
	};
}