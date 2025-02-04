namespace ZZZDmgCalculator.Components.Main;

using Microsoft.AspNetCore.Components;
using Models.State;
using Extensions;
using ZZZ.ApiModels;

public partial class OverviewCard {
    [Parameter]
    public AgentState Agent { get; set; } = null!;
    
	async Task OpenAgentDialog() {
		if (await Dialogs.OpenAgentDialog() is {} a)
		{
			Notifier.SwapCurrentAgent(a);
		}
	}
	void ChangeCinema(int value) {
		Agent.Cinema = value;
		// update all cinema buffs
		Notifier.CurrentAgentChanged(); // notify to re-render all the main page, TODO: maybe only re-render the buffs tab
	}
	void AscensionChanged(AscensionState obj) {
		Agent.Ascension = obj;
		Notifier.CurrentAgentChanged();
	}
}