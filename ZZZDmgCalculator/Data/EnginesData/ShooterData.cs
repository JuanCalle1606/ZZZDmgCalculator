namespace ZZZDmgCalculator.Data.EnginesData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;


[InfoData<Engines>(Engines.Shooter)]
public class ShooterData {
	public readonly static EngineInfo Data = new()
	{
		Uid = Engines.Shooter,
		Icon = "Six_Shooter",
		Rank = ItemRank.A,
		Type = Specialties.Stun,  
		MainStat = new()
		{
			Stat = Stats.Atk
		},
		MainStats = EngineScales.Templates["GameBall.Main"],
		SubStat = new()
		{
			Stat = Stats.Impact,
			Type = StatModifiers.BasePercent
		},
		SubStats = EngineScales.Templates["Shooter.Sub"]
	};
}