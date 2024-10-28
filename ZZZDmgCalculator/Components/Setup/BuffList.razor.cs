namespace ZZZDmgCalculator.Components.Setup;

using Microsoft.AspNetCore.Components;
using Models.State;

public partial class BuffList {
	[Parameter]
	public List<BuffState> Buffs { get; set; } = null!;

	[Parameter]
	public string Title { get; set; } = "";
}