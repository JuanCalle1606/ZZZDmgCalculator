namespace ZZZDmgCalculator.Data.DiscsData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;

[InfoData<Discs>(Discs.HormonePunk)]
public class HormonePunkData {
	public readonly static DiscInfo Data = new()
	{
		Uid = Discs.HormonePunk,
		StatBuff = new()
		{
			Stat = Stats.Atk,
			Value = 10,
			Type = StatModifiers.BasePercent
		},
		Buffs = new BuffInfo()
		{
			Modifiers = new StatModifier
			{
				Stat = Stats.Atk,
				Value = 25,
				Type = StatModifiers.CombatPercent
			}
		}
	};
}