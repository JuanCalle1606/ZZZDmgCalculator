namespace ZZZDmgCalculator.Data.Engines;

using Models.Enum;
using Models.Info;

[InfoData<Engines>(Engines.Teapot)]
public class TeapotData {
	public readonly static EngineInfo Data = new()
	{
		Id = nameof(Engines.Teapot),
		Icon = "Ice-Jade_Teapot",
		Rank = ItemRank.S,
		Type = Specialties.Stun,  // Corrección: Type es Stun
		MainStat = new()
		{
			Stat = Stats.Atk
		},
		MainStats = EngineScales.Templates["Stinger.Main"],
		SubStat = new()
		{
			Stat = Stats.Impact,
			Type = StatModifiers.BasePercent
		},
		SubStats = EngineScales.Templates["Teapot.Sub"],
		Passives =
		[
			new()
			{
				Scales = [EngineScales.Templates["Teapot.Buff"]],
				Type = BuffTrigger.Stack,
				Stacks = 30,
				Modifiers = new StatModifier
				{
					Stat = Stats.Impact,
					Type = StatModifiers.CombatPercent
				}
			},

			new()
			{
				Scales = [EngineScales.Templates["Base.Buff"]],
				Type = BuffTrigger.Permanent,
				Depends = 0,
				RequiredStacks = 15,
				Modifiers = new StatModifier
				{
					Stat = Stats.BonusDmg, Type = StatModifiers.Combat,
					Shared = true
				}
			}
		]
	};
}