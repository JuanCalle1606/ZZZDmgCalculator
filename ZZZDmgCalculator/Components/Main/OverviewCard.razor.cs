namespace ZZZDmgCalculator.Components.Main;

using Microsoft.AspNetCore.Components;
using Models.State;
using Extensions;

public partial class OverviewCard {
    [Parameter]
    public AgentState Agent { get; set; } = null!;
    
	async Task OpenAgentDialog() {
		if (await Dialogs.OpenAgentDialog() is {} a)
		{
			Notifier.SwapCurrentAgent(a);
		}
	}
}