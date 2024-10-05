namespace ZZZDmgCalculator.Data.Engines;

using Models.Enum;
using Models.Info;

[InfoData<Engines>(Engines.ElectroLip)]
public class ElectroLipData {
	public readonly static EngineInfo Data = new()
	{
		Id = nameof(Engines.ElectroLip),
		Icon = "Electro-Lip_Gloss",
		Rank = ItemRank.A,
		Type = Specialties.Anomaly,
		MainStat = new()
		{
			Stat = Stats.Atk
		},
		MainStats = EngineScales.Templates["GameBall.Main"],
		SubStat = new()
		{
			Stat = Stats.Proficiency,
			Type = StatModifiers.BaseFlat
		},
		SubStats = EngineScales.Templates["Rainforest.Sub"],
		Passives =
		[
			new()
			{
				Scales = [EngineScales.Templates["Spring.Buff1"]],
				Modifiers =
				[
					new()
					{
						Stat = Stats.Atk,
						Type = StatModifiers.CombatPercent
					},

					new()
					{
						Stat = Stats.BonusDmg
					}
				]
			}
		]
	};
}