namespace ZZZDmgCalculator.Data.EnginesData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;


[InfoData<Engines>(Engines.Mark1)]
public class Mark1Data {
	public readonly static EngineInfo Data = new()
	{
		Id = nameof(Engines.Mark1),
		Icon = "(Reverb)_Mark_I",
		Rank = ItemRank.B,
		Type = Specialties.Support,
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
		Passives =
		[
			new()
			{
				Scales = [EngineScales.Templates["Mark1.Buff"]],
				Modifiers = new StatModifier
				{
					Stat = Stats.Impact,
					Shared = true,
					Type = StatModifiers.CombatPercent
				}
			}
		]
	};
}