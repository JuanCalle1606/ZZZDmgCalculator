namespace ZZZDmgCalculator.Services;

using Models.State;
using ZZZ.ApiModels;

public class StateService {

	public int CurrentAgentIndex { get; set; }

	public SetupState CurrentSetup { get; set; } = new();

	public AgentState? CurrentAgent
	{
		get => CurrentSetup[CurrentAgentIndex]!;
		set => CurrentSetup[CurrentAgentIndex] = value;
	}
	
	public StateService(InfoService info) {
		// set ellen by default
		CurrentSetup[0] = new(info[Agents.Ellen]);
		CurrentAgentIndex = 0;
	}
}