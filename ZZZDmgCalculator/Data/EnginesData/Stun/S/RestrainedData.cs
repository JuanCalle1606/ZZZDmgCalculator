namespace ZZZDmgCalculator.Data.EnginesData.Stun.S;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;

[InfoData<Engines>(Engines.Restrained)]
public class RestrainedData {
	public readonly static EngineInfo Data = new()
	{
		Uid = Engines.Restrained,
		Icon = "The_Restrained",
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
		SubStats = EngineScales.Templates["Teapot.Sub"]
	};
}