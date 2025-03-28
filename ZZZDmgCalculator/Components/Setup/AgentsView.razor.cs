namespace ZZZDmgCalculator.Components.Setup;

using Extensions;
using Microsoft.AspNetCore.Components;
using Models.State;
using Radzen;

public partial class AgentsView {
	[Parameter]
	public AgentState?[] Agents { get; set; } = null!;

	bool CanRemove => Agents.Count(i=>i != null) > 1;

	JustifyContent Justify => State.CurrentAgentIndex switch {
		0 => JustifyContent.Start,
		1 => JustifyContent.Center,
		2 => JustifyContent.End,
		_ => JustifyContent.SpaceEvenly
	};

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
		// make sure the current agent is updated
		State.CurrentAgent?.UpdateAllStats();
		Notifier.CurrentAgentChanged();
	}
	
	void RemoveAgent() {
		if(!CanRemove) return;
		// get the index of other agent to swap to
		var index = Agents.Select((a, i) => (a, i)).First(i => i.a != null && i.i != State.CurrentAgentIndex).i;
		State.CurrentAgent = null;
		State.CurrentAgentIndex = index;
		foreach (var agent in Agents.Where(a=>a is not null))
		{
			agent!.UpdateAllStats();
			
		}
		Notifier.CurrentAgentChanged();
	}
	
	void MoveRight() {
		var newIndex = State.CurrentAgentIndex + 1;
		if(newIndex >= Agents.Length) newIndex = 0;
		
		(Agents[newIndex], Agents[State.CurrentAgentIndex]) = (Agents[State.CurrentAgentIndex], Agents[newIndex]);
		
		State.CurrentAgentIndex = newIndex;
	}
	
	void MoveLeft() {
		var newIndex = State.CurrentAgentIndex - 1;
		if(newIndex < 0) newIndex = Agents.Length - 1;
		
		(Agents[newIndex], Agents[State.CurrentAgentIndex]) = (Agents[State.CurrentAgentIndex], Agents[newIndex]);
		
		State.CurrentAgentIndex = newIndex;
		
	}
}