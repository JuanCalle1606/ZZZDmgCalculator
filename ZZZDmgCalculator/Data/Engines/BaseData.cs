namespace ZZZDmgCalculator.Data.Engines;

using Models.Enum;
using Models.Info;

[InfoData<Engines>(Engines.Base)]
public class BaseData {
	public readonly static EngineInfo Data = new()
	{
		Id = nameof(Engines.Base),
		Icon = "(Identity)_Base",
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
				Scales = [EngineScales.Templates["Base.Buff"]],
				Modifiers = new StatModifier
				{
					Stat = Stats.Def,
					Type = StatModifiers.CombatPercent
				}
			}
		]
	};
}