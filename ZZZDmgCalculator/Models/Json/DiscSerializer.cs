namespace ZZZDmgCalculator.Models.Json;

using Common;
using Extensions;
using Info;
using Services;
using State;
using ZZZ.ApiModels.Responses;

public static class DiscSerializer {


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
	static List<Agent.Stat> StateToModel(SubStatsContainer discSubStats) =>
		discSubStats.Select((s, i) => StatToModel(s, discSubStats.Modifiers[i], discSubStats.Rolls[i])).ToList();

	static Agent.Stat StatToModel(DiscStatInfo stat, StatModifier value, int rolls = 0) {
		return new()
		{
			Id = stat.Uid,
			Name = stat.DisplayName,
			Value = value.Format(),
			Rolls = rolls + 1
		};
	}

	public static void ModelToState(List<Agent.Disc> discs, AgentState state, InfoService info) {
		foreach (var disc in discs)
		{
			var mainStat = info[disc.MainStat!.Id];
			var discState = new DiscState(info[disc.Id], mainStat)
			{
				Rank = disc.Rank,
				Level = disc.Level,
			};

			foreach (var subStat in disc.SubStats)
			{
				var subStatInfo = info[subStat.Id];
				discState.SubStats.Add(subStatInfo, subStat.Rolls - 1);
			}
			state.SetDisc(discState, disc.Slot);
		}
	}
}