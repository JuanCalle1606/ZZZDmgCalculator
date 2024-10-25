using Microsoft.AspNetCore.Components;

namespace ZZZDmgCalculator.Components.Setup;

using Models.Enum;

public partial class ItemRankSelector {

	bool _open;
	
	[Parameter]
	public ItemRank Rank { get; set; }
	
	[Parameter]
	public EventCallback<ItemRank> RankChanged { get; set; }

	void OpenSelector() {
		_open = true;
	}
	
	Task SelectRank(ItemRank rank) {
		_open = false;
		return RankChanged.InvokeAsync(rank);
	}
}