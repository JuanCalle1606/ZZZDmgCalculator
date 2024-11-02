namespace ZZZDmgCalculator.Dialogs;

using Microsoft.AspNetCore.Components;
using Models.Info;
using Models.State;
using ZZZ.ApiModels;

public partial class ChooseDiscDialog {
	string _searchFilter = string.Empty;

	DiscInfo[] _discs = null!;
	DiscStatInfo[] _statData = null!;

	[Parameter]
	public int Index { get; set; }

	protected override void OnInitialized() {
		base.OnInitialized();
		_discs = Enum.GetValues<Discs>().Select(e => Info[e]).ToArray();
		_statData = Info.AllStatInfos
			.Where(statInfo => statInfo.IsMain)
			.SelectMany(statInfo => statInfo.DiscData).ToArray();
	}

	bool ApplyFilters(DiscInfo e) => e.DisplayName.Contains(_searchFilter, StringComparison.CurrentCultureIgnoreCase);

	DiscState CreateDiscState(DiscInfo info) {
		var discStats = _statData
			.First(di => di.MainDiscs!.Contains(Index + 1));
		// disc are by default rank S so lets add 3 substats
		var subStats = Info.AllStatInfos
			.Where(statInfo => statInfo.IsMain)
			.SelectMany(statInfo => statInfo.DiscData)
			.ToArray();
		var state = new DiscState(info, discStats);
		
		for (var i = 0; i < 3; i++)
		{
			state.SubStats.Add(subStats[i]);
		}
		
		return state;
	}
}