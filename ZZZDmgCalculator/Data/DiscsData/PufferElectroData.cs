namespace ZZZDmgCalculator.Data.DiscsData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;
using static ZZZ.ApiModels.Skills;

[InfoData<Discs>(Discs.PufferElectro)]
public class PufferElectroData {
	public readonly static DiscInfo Data = new ()
	{
		Uid = Discs.PufferElectro,
		StatBuff = new ()
		{
			Stat = Stats.PenRatio,
			Value = 8
		},
		Buffs =
		[
			new ()
			{
				Type = BuffTrigger.Permanent,
				Modifiers = new StatModifier
				{
					Stat = Stats.UltimateDmg, Type = StatModifiers.Combat,
					Value = 20
				}
			},

			new ()
			{
				Modifiers = new StatModifier
				{
					Stat = Stats.Atk,
					Value = 15,
					Type = StatModifiers.CombatPercent
				}
			}
		]
	};
}