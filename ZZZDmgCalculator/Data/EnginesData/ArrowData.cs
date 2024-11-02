namespace ZZZDmgCalculator.Data.EnginesData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;


[InfoData<Engines>(Engines.Arrow)]
public class ArrowData {
	public readonly static EngineInfo Data = new()
	{
		Uid = Engines.Arrow,
		Icon = "(Vortex)_Arrow",
		Rank = ItemRank.B,
		Type = Specialties.Stun,
		MainStat = new()
		{
			Stat = Stats.Atk
		},
		MainStats = EngineScales.Templates["Mark1.Main"],
		SubStat = new()
		{
			Stat = Stats.Impact,
			Type = StatModifiers.BasePercent
		},
		SubStats = EngineScales.Templates["Arrow.Sub"]
	};
}