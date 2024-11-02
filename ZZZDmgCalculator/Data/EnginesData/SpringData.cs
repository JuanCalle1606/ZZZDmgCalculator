namespace ZZZDmgCalculator.Data.EnginesData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;


[InfoData<Engines>(Engines.Spring)]
public class SpringData {
	public readonly static EngineInfo Data = new()
	{
		Uid = Engines.Spring,
		Icon = "Spring_Embrace",
		Rank = ItemRank.A,
		Type = Specialties.Defense,
		MainStat = new()
		{
			Stat = Stats.Atk
		},
		MainStats = EngineScales.Templates["GameBall.Main"],
		SubStat = new()
		{
			Stat = Stats.Atk,
			Type = StatModifiers.BasePercent
		},
		SubStats = EngineScales.Templates["SliceOfTime.Sub"],
		Passives =
		[
			new()
			{
				Scales = [EngineScales.Templates["Spring.Buff"]],
				Type = BuffTrigger.Permanent,
				Modifiers = new StatModifier
				{
					Stat = Stats.DmgReduction
				}
			},

			new()
			{
				Scales = [EngineScales.Templates["Spring.Buff1"]],
				Pass = true,
				Modifiers = new StatModifier
				{
					Stat = Stats.EnergyRegen,
					Type = StatModifiers.CombatPercent
				}
			}
		]
	};
}