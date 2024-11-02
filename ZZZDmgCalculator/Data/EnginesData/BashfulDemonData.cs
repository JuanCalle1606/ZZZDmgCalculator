namespace ZZZDmgCalculator.Data.EnginesData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;


[InfoData<Engines>(Engines.BashfulDemon)]
public class BashfulDemonData {
	public readonly static EngineInfo Data = new()
	{
		Id = nameof(Engines.BashfulDemon),
		Icon = "Bashful_Demon",
		Rank = ItemRank.A,
		Type = Specialties.Support,
		MainStat = new()
		{
			Stat = Stats.Atk
		},
		MainStats = EngineScales.Templates["TheVault.Main"],
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
				Scales = [EngineScales.Templates["TheVault.Buff"]],
				Type = BuffTrigger.Permanent,
				Modifiers = new StatModifier
				{
					Stat = Stats.IceDmg,
					Type = StatModifiers.Combat
				}
			},

			new()
			{
				Scales = [EngineScales.Templates["BashfulDemon.Buff"]],
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