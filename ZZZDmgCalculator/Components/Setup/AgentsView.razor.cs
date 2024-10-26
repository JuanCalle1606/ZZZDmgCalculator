namespace ZZZDmgCalculator.Components.Setup;

using Microsoft.AspNetCore.Components;
using Models.State;
using Util;

public partial class AgentsView {
	[Parameter]
	public AgentState?[] Agents { get; set; } = null!;

	async Task ChooseAgent(int li) {
		if (await Dialogs.OpenAgentDialog() is {} a)
		{
			State.CurrentAgentIndex = li;
			Notifier.SwapCurrentAgent(a);
		}
	}
	void ClickAgent(int li) {
		if(li == State.CurrentAgentIndex) return;
		State.CurrentAgentIndex = li;
		Notifier.CurrentAgentChanged();
	}
}