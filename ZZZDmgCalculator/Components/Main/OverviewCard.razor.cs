namespace ZZZDmgCalculator.Components.Main;

using System.Collections;
using MessagePipe;
using Microsoft.AspNetCore.Components;
using Models.Enum;
using Models.State;
using Pages;
using Util;

public partial class OverviewCard {
    static IEnumerable AscensionData => Enum.GetValues<AscensionState>();
    
    [Parameter]
    public AgentState Agent { get; set; } = null!;
    
	async Task OpenAgentDialog() {
		if (await Dialogs.OpenAgentDialog() is {} a)
		{
			Notifier.SwapCurrentAgent(a);
		}
	}

	protected override void OnDisposableBag(DisposableBagBuilder bag) {
		base.OnDisposableBag(bag);
	}
}