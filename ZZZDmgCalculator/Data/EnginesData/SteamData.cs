namespace ZZZDmgCalculator.Data.EnginesData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;


[InfoData<Engines>(Engines.Steam)]
public class SteamData {
	public readonly static EngineInfo Data = new()
	{
		Id = nameof(Engines.Steam),
		Icon = "Steam_Oven",
		Rank = ItemRank.A,
		Type = Specialties.Stun,  
		MainStat = new()
		{
			Stat = Stats.Atk
		},
		MainStats = EngineScales.Templates["GameBall.Main"],
		SubStat = new()
		{
			Stat = Stats.EnergyRegen,
			Type = StatModifiers.BasePercent
		},
		SubStats = EngineScales.Templates["GameBall.Sub"],
		Passives =
		[
			new()
			{
				Scales = [EngineScales.Templates["BashfulDemon.Buff"]],
				Type = BuffTrigger.Stack,
				Stacks = 8,
				Modifiers = new StatModifier
				{
					Stat = Stats.Impact,
					Type = StatModifiers.CombatPercent
				}
			}
		]
	};
}