namespace ZZZDmgCalculator.Data.EnginesData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;


[InfoData<Engines>(Engines.Mark3)]
public class Mark3Data {
	public readonly static EngineInfo Data = new()
	{
		Uid = Engines.Mark3,
		Icon = "(Reverb)_Mark_III",
		Rank = ItemRank.B,
		Type = Specialties.Support,
		MainStat = new()
		{
			Stat = Stats.Atk
		},
		MainStats = EngineScales.Templates["Mark1.Main"],
		SubStat = new()
		{
			Stat = Stats.Hp,
			Type = StatModifiers.BasePercent
		},
		SubStats = EngineScales.Templates["Mark1.Sub"],
		Passives =
		[
			new()
			{
				Scales = [EngineScales.Templates["Mark2.Buff"]],
				Modifiers = new StatModifier
				{
					Stat = Stats.Atk,
					Shared = true,
					Type = StatModifiers.CombatPercent
				}
			}
		]
	};
}