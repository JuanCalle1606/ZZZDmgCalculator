namespace ZZZDmgCalculator.Data.EnginesData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;


[InfoData<Engines>(Engines.Bunny)]
public class BunnyData {
	public readonly static EngineInfo Data = new()
	{
		Uid = Engines.Bunny,
		Icon = "Bunny_Band",
		Rank = ItemRank.A,
		Type = Specialties.Defense,
		MainStat = new()
		{
			Stat = Stats.Atk
		},
		MainStats = EngineScales.Templates["GameBall.Main"],
		SubStat = new()
		{
			Stat = Stats.Def,
			Type = StatModifiers.BasePercent
		},
		SubStats = EngineScales.Templates["Mark2.Sub"],
		Passives =
		[
			new()
			{
				Scales = [EngineScales.Templates["Transmorpher.Buff"]],
				Type = BuffTrigger.Permanent,
				Modifiers = new StatModifier
				{
					Stat = Stats.Hp,
					Type = StatModifiers.CombatPercent
				}
			},

			new()
			{
				Scales = [EngineScales.Templates["Spring.Buff1"]],
				Modifiers = new StatModifier
				{
					Stat = Stats.Atk,
					Type = StatModifiers.CombatPercent
				}
			}
		]
	};
}