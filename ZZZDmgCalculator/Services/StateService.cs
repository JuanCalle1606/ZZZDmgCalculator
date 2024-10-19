namespace ZZZDmgCalculator.Services;

using Models.Enum;
using Models.State;

public class StateService {
	InfoService _info;

	public int CurrentAgentIndex { get; }

	public SetupState CurrentSetup { get; set; } = new();

	public AgentState CurrentAgent
	{
		get => CurrentSetup.Agents[CurrentAgentIndex]!;
		set => CurrentSetup.Agents[CurrentAgentIndex] = value;
	}
	
	public StateService(InfoService info) {
		_info = info;
		// set ellen by default
		CurrentSetup.Agents[0] = new(_info[Agents.Anby]);
		CurrentAgentIndex = 0;
	}
}