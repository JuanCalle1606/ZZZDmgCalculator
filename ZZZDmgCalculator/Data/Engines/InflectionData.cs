namespace ZZZDmgCalculator.Data.Engines;

using Models.Enum;
using Models.Info;

[InfoData<Engines>(Engines.Inflection)]
public class InflectionData {
	public readonly static EngineInfo Data = new()
	{
		Id = nameof(Engines.Inflection),
		Icon = "(Identity)_Inflection",
		Rank = ItemRank.B,
		Type = Specialties.Defense,
		MainStat = new()
		{
			Stat = Stats.Atk
		},
		MainStats = EngineScales.Templates["Mark1.Main"],
		SubStat = new()
		{
			Stat = Stats.Def,
			Type = StatModifiers.BasePercent
		},
		SubStats = EngineScales.Templates["Inflection.Sub"],
		Passives =
		[
			new()
			{
				Scales = [EngineScales.Templates["Inflection.Buff"]],
				Modifiers = new StatModifier
				{
					Stat = Stats.DmgReduction
				}
			}
		]
	};
}