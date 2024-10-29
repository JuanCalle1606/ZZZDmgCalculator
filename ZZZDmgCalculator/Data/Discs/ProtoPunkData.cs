namespace ZZZDmgCalculator.Data.Discs;

using Models.Enum;
using Models.Info;
using static Models.Enum.Discs;
using static Models.Enum.StatModifiers;
using static Models.Enum.Stats;

[InfoData<Discs>(ProtoPunk)]
public class ProtoPunkData {
	public readonly static DiscInfo Data = new()
	{
		Id = nameof(ProtoPunk),
		StatBuff = new()
		{
			Stat = ShieldPower,
			Value = 15,
		},
		Buffs = new StatModifier()
		{
			Stat = BonusDmg, Type = Combat,
			Shared = true,
			Value = 15
		}
	};
}