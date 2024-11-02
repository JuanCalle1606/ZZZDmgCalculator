namespace ZZZDmgCalculator.Data.EnginesData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;


[InfoData<Engines>(Engines.Rock)]
public class RockData {
	public readonly static EngineInfo Data = new()
	{
		Id = nameof(Engines.Rock),
		Icon = "Precious_Fossilized_Core",
		Rank = ItemRank.A,
		Type = Specialties.Stun,  
		MainStat = new()
		{
			Stat = Stats.Atk
		},
		MainStats = EngineScales.Templates["GameBall.Main"],
		SubStat = new()
		{
			Stat = Stats.Impact,
			Type = StatModifiers.BasePercent
		},
		SubStats = EngineScales.Templates["Shooter.Sub"],
		Passives =
		[
			// TODO: Require daze implement
			/*
			new()
			{
				Scales = [EngineScales.Templates["Spring.Buff1"]],
				Modifiers = new StatModifier
				{
					Stat = Stats.Impact,
					Type = StatModifiers.CombatPercent
				}
			},

			new()
			{
				Scales = [EngineScales.Templates["Spring.Buff1"]],
				Depends = 0,
				Modifiers = new StatModifier
				{
					Stat = Stats.Impact,
					Type = StatModifiers.CombatPercent
				}
			}*/
		]
	};
}