using Microsoft.AspNetCore.Components;

namespace ZZZDmgCalculator.Components.Setup;

using Models.Enum;
using Models.Info;
using Models.State;
using Util;

public partial class DiscView {
	DiscStatInfo[] _discStatInfos = null!;
	DiscStatInfo[] _discSubStatInfos = null!;

	[Parameter]
	public DiscState Disc { get; set; } = null!;

	[Parameter]
	public int Index { get; set; }

	protected override void OnParametersSet() {
		base.OnParametersSet();
		_discStatInfos = Info.AllStatInfos.Where(si => si.IsMain).SelectMany(si => si.DiscData).Where(dd => dd.MainDiscs!.Contains(Index + 1)).ToArray();
		_discSubStatInfos = Info.AllStatInfos.Where(si => si.IsSub).SelectMany(si => si.DiscData).ToArray();
	}

	async Task OpenDiscDialog() {
		// open disc choose dialog
		if (await Dialogs.OpenDiscDialog(Index) is {} info)
		{
			Notifier.SwapCurrentDisc(Index, info);
		}
	}

	DiscStatInfo[] AvaliableSubStats(DiscStatInfo stat) {
		return _discSubStatInfos.Where(ss => ss == stat || !Disc.SubStats.Contains(ss)).ToArray();
	}
	
	void RankChanged(ItemRank rank) {
		Disc.Rank = rank;
		State.CurrentAgent.UpdateAllStats();
		Notifier.CurrentDiscUpdated(Index);
	}

	void LevelChanged(int level) {
		Disc.Level = level;
		State.CurrentAgent.UpdateAllStats();
		Notifier.CurrentDiscUpdated(Index);
	}

	void RemoveDisc() {
		Notifier.SwapCurrentDisc(Index, null);
	}
	void MainStatChanged(int i) {
		var newStat = _discStatInfos[i];
		Disc.MainStatInfo = newStat;
		State.CurrentAgent.UpdateAllStats();
		Notifier.CurrentDiscUpdated(Index);
	}
	string GetStatDisplay(DiscStatInfo stat, int li) {
		return $"{Info[stat.Buff.Stat].DisplayName}{(stat.Buff.IsPercent ? "%" : "")}";
	}
	void SubStatChanged(DiscStatInfo stat, DiscStatInfo newStat) {
		// we want to keep the same roll but change the stat
		Disc.SubStats.Replace(stat, newStat);
		
		State.CurrentAgent.UpdateAllStats();
		Notifier.CurrentDiscUpdated(Index);
	}
	void AddNewSubStat() {
		var newStat = _discSubStatInfos.First(ss => !Disc.SubStats.Contains(ss));
		Disc.SubStats.Add(newStat);
		State.CurrentAgent.UpdateAllStats();
		Notifier.CurrentDiscUpdated(Index);
	}
	void RollsChanged(int li, int i1) {
		Disc.SubStats.Rolls[li] = i1;
		State.CurrentAgent.UpdateAllStats();
		Notifier.CurrentDiscUpdated(Index);
	}
}