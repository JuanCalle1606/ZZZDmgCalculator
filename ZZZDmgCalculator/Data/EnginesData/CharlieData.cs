namespace ZZZDmgCalculator.Data.EnginesData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;


[InfoData<Engines>(Engines.Charlie)]
public class CharlieData {
	public readonly static EngineInfo Data = new()
	{
		Id = nameof(Engines.Charlie),
		Icon = "(Magnetic_Storm)_Charlie",
		Rank = ItemRank.B,
		Type = Specialties.Anomaly,
		MainStat = new()
		{
			Stat = Stats.Atk
		},
		MainStats = EngineScales.Templates["Mark1.Main"],
		SubStat = new()
		{
			Stat = Stats.PenRatio
		},
		SubStats = EngineScales.Templates["Charlie.Sub"]
	};
}