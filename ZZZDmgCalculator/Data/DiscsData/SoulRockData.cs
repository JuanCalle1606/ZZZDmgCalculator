namespace ZZZDmgCalculator.Data.DiscsData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;

[InfoData<Discs>(Discs.SoulRock)]
public class SoulRockData {
	public readonly static DiscInfo Data = new()
	{
		Uid = Discs.SoulRock,
		StatBuff = new()
		{
			Stat = Stats.Def,
			Value = 16,
			Type = StatModifiers.BasePercent
		},
		Buffs = new BuffInfo() // TODO: maybe remove this buff because DmgReduction in agents dont affect the dmg they deal.
		{
			Modifiers = new StatModifier
			{
				Stat = Stats.DmgReduction,
				Value = 40
			}
		}
	};
}