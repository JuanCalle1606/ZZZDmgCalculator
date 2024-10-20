namespace ZZZDmgCalculator.Pages;

using Models.State;

public partial class Main {
	public void AgentSwap(AgentState stateCurrentAgent) {
		State.CurrentAgent = stateCurrentAgent;
		StateHasChanged();
	}
	
	public void FullUpdate() {
		StateHasChanged();
	}
}