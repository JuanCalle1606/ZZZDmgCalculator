namespace ZZZDmgCalculator.Data.Engines;

using Models.Enum;
using Models.Info;

[InfoData<Engines>(Engines.Noviluna)]
public class NovilunaData {
	public readonly static EngineInfo Data = new()
	{
		Id = nameof(Engines.Noviluna),
		Icon = "(Lunar)_Noviluna",
		Rank = ItemRank.B,
		Type = Specialties.Attack,
		MainStat = new()
		{
			Stat = Stats.Atk
		},
		MainStats = EngineScales.Templates["Mark1.Main"],
		SubStat = new()
		{
			Stat = Stats.CritRate
		},
		SubStats = EngineScales.Templates["Charlie.Sub"]
	};
}