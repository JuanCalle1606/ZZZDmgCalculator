namespace ZZZDmgCalculator.Data.EnginesData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;


[InfoData<Engines>(Engines.Revolver)]
public class RevolverData {
	public readonly static EngineInfo Data = new()
	{
		Id = nameof(Engines.Revolver),
		Icon = "(Vortex)_Revolver",
		Rank = ItemRank.B,
		Type = Specialties.Stun,  
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
		// TODO: Add the stun passive
	};
}