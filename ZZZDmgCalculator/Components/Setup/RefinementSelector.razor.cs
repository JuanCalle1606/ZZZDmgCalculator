using Microsoft.AspNetCore.Components;

namespace ZZZDmgCalculator.Components.Setup;

public partial class RefinementSelector {
	
	
	[Parameter]
	public int Value { get; set; }
	
	[Parameter]
	public EventCallback<int> ValueChanged { get; set; }
}