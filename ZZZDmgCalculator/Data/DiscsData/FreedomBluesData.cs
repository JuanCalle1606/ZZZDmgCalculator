namespace ZZZDmgCalculator.Data.DiscsData;

using Models.Enum;
using Models.Info;
using ZZZ.ApiModels;

[InfoData<Discs>(Discs.FreedomBlues)]
public class FreedomBluesData {
	public readonly static DiscInfo Data = new ()
	{
		Id = nameof(Discs.FreedomBlues),
		StatBuff = new ()
		{
			Stat = Stats.Proficiency,
			Value = 30,
			Type = StatModifiers.BaseFlat
		}
	};
}