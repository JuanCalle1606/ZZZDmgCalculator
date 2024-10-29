namespace ZZZDmgCalculator.Data.Engines;

using Models.Enum;
using Models.Info;

[InfoData<Engines>(Engines.TheVault)]
public class TheVaultData {
	public readonly static EngineInfo Data = new()
	{
		Id = nameof(Engines.TheVault),
		Icon = "The_Vault",
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
				Scales = [EngineScales.Templates["TheVault.Buff"], EngineScales.Templates["TheVault.Buff2"]],
				Modifiers =
				[
					new StatModifier
					{
						Stat = Stats.BonusDmg,
						Shared = true,
						Type = StatModifiers.Combat
					},
					new StatModifier
					{
						Stat = Stats.EnergyRegen,
						Type = StatModifiers.CombatFlat
					}
				]
			}
		]
	};
}