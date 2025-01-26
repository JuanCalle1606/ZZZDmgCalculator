namespace ZZZDmgCalculator.Data.EnginesData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;
using static ZZZ.ApiModels.Skills;
using static Models.Enum.StatModifiers;
using static Models.Enum.Stats;

[InfoData<Engines>(Engines.Pleniluna)]
public class PlenilunaData {
	public readonly static EngineInfo Data = new()
	{
		Uid = Engines.Pleniluna,
		Icon = "(Lunar)_Pleniluna",
		Rank = ItemRank.B,
		Type = Specialties.Attack,
		MainStat = new()
		{
			Stat = Atk
		},
		MainStats = EngineScales.Templates["Mark1.Main"],
		SubStat = new()
		{
			Stat = Atk,
			Type = BasePercent
		},
		SubStats = EngineScales.Templates["Mark1.Sub"],
		Passives =
		[
			new()
			{
				Scales = [EngineScales.Templates["Pleniluna.Buff"]],
				Type = BuffTrigger.Permanent,
				Modifiers =
				[
					new() { Stat = BasicDmg, Type = Combat },
					new() { Stat = DashDmg, Type = Combat },
					new() { Stat = DodgeDmg, Type = Combat }
				]
			}
		]
	};
}