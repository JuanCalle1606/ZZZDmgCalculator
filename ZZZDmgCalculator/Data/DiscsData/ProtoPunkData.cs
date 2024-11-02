namespace ZZZDmgCalculator.Data.DiscsData;

using Models.Info;
using ZZZ.ApiModels;
using static ZZZ.ApiModels.Discs;
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