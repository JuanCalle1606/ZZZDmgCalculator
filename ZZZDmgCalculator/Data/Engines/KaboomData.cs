namespace ZZZDmgCalculator.Data.Engines;

using Models.Enum;
using Models.Info;

[InfoData<Engines>(Engines.Kaboom)]
public class KaboomData {
	public readonly static EngineInfo Data = new()
	{
		Id = nameof(Engines.Kaboom),
		Icon = "Kaboom_the_Cannon",
		Rank = ItemRank.A,
		Type = Specialties.Support,
		MainStat = new()
		{
			Stat = Stats.Atk
		},
		MainStats = EngineScales.Templates["TheVault.Main"],
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
				Scales = [EngineScales.Templates["Kaboom.Buff"]],
				Type = BuffTrigger.Stack,
				Stacks = 4,
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