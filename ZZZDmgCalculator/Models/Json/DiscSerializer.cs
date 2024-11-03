namespace ZZZDmgCalculator.Models.Json;

using Common;
using Extensions;
using Info;
using State;
using ZZZ.ApiModels.Responses;

public static class DiscSerializer  {


	public static Agent.Disc? StateToModel(DiscState? disc, int index) {
		if (disc is null) return null;
		return new()
		{
			Id = disc.Info.Uid,
			Level = disc.Level,
			Slot = index,
			Name = disc.Info.DisplayName,
			Rank = disc.Rank,
			MainStat = StatToModel(disc.MainStatInfo, disc.Modifiers.First()),
			SubStats = StateToModel(disc.SubStats)
		};
	}
	static Agent.Disc.Stat[] StateToModel(SubStatsContainer discSubStats) => 
		discSubStats.Select((s, i) => StatToModel(s, discSubStats.Modifiers[i], discSubStats.Rolls[i])).ToArray();

	static Agent.Disc.Stat StatToModel(DiscStatInfo stat, StatModifier value, int rolls = -1) {
		return new()
		{
			Id = stat.Uid,
			Name = stat.DisplayName,
			Value = value.Format(),
			Rolls = rolls
		};
	}
}