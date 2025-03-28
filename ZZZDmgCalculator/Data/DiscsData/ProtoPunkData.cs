namespace ZZZDmgCalculator.Data.DiscsData;

using Models.Info;
using ZZZ.ApiModels;
using static Models.Enum.StatModifiers;
using static Models.Enum.Stats;
using static ZZZ.ApiModels.Discs;

[InfoData<Discs>(ProtoPunk)]
public class ProtoPunkData {
	public readonly static DiscInfo Data = new()
	{
		Uid = ProtoPunk,
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