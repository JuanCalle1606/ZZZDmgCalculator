namespace ZZZDmgCalculator.Data.EnginesData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;


[InfoData<Engines>(Engines.Mark2)]
public class Mark2Data {
	public readonly static EngineInfo Data = new()
	{
		Uid = Engines.Mark2,
		Icon = "(Reverb)_Mark_II",
		Rank = ItemRank.B,
		Type = Specialties.Support,
		MainStat = new()
		{
			Stat = Stats.Atk
		},
		MainStats = EngineScales.Templates["Mark1.Main"],
		SubStat = new()
		{
			Stat = Stats.EnergyRegen,
			Type = StatModifiers.BasePercent
		},
		SubStats = EngineScales.Templates["Mark2.Sub"],
		Passives =
		[
			new()
			{
				Scales = [EngineScales.Templates["Mark2.Buff"]],
				Modifiers =
				[
					new()
					{
						Stat = Stats.Mastery,
						Shared = true,
						Type = StatModifiers.CombatFlat
					},

					new()
					{
						Stat = Stats.Proficiency,
						Shared = true,
						Type = StatModifiers.CombatFlat
					}
				]
			}
		]
	};
}