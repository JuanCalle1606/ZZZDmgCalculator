namespace ZZZDmgCalculator.Data.EnginesData.Attack.S;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;

[InfoData<Engines>(Engines.Brimstone)]
public class BrimstoneData {
	public readonly static EngineInfo Data = new()
	{
		Uid = Engines.Brimstone,
		Icon = "The_Brimstone",
		Rank = ItemRank.S,
		Type = Specialties.Attack,
		MainStat = new()
		{
			Stat = Stats.Atk
		},
		MainStats = EngineScales.Templates["Cradle.Main"],
		SubStat = new()
		{
			Stat = Stats.Atk,
			Type = StatModifiers.BasePercent
		},
		SubStats = EngineScales.Templates["Brimstone.Sub"],
		Passives =
		[
			new()
			{
				Scales = [EngineScales.Templates["Brimstone.Buff"]],
				Type = BuffTrigger.Stack,
				Stacks = 8,
				Modifiers = new StatModifier
				{
					Stat = Stats.Atk,
					Type = StatModifiers.CombatPercent
				}
			}
		]
	};
}