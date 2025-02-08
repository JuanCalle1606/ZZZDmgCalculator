namespace ZZZDmgCalculator.Components.Setup;

using Microsoft.AspNetCore.Components;
using Models.State;

public partial class BuffList {
	[Parameter]
	public IEnumerable<BuffState> Buffs { get; set; } = null!;

	[Parameter]
	public string Title { get; set; } = "";
	
	List<BuffState> _showBuffs = [];

	protected override void OnParametersSet() {
		_showBuffs = Buffs.Where(b => !b.Hidden).ToList();
	}
}