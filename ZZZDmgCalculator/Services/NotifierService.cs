namespace ZZZDmgCalculator.Services;

using MessagePipe;
using Models.State;

public class NotifierService : IDisposable {
	
	readonly StateService _stateService;

	readonly IDisposablePublisher<AgentState> _currentAgentChangedPublisher;
	public ISubscriber<AgentState> OnCurrentAgentChanged { get; }
	
	readonly IDisposablePublisher<EngineState?> _currentEngineChangedPublisher;
	public ISubscriber<EngineState?> OnCurrentEngineChanged { get; }

	public NotifierService(EventFactory eventFactory, StateService stateService) {
		_stateService = stateService;
		(_currentAgentChangedPublisher, OnCurrentAgentChanged) = eventFactory.CreateEvent<AgentState>();
		(_currentEngineChangedPublisher, OnCurrentEngineChanged) = eventFactory.CreateEvent<EngineState?>();
	}
	
	public void SwapCurrentAgent(AgentState newAgent) {
		_stateService.CurrentAgent = newAgent;
		
		_currentAgentChangedPublisher.Publish(_stateService.CurrentAgent);
	}

	public void SwapCurrentEngine(EngineState newEngine) {
		_stateService.CurrentAgent.Engine = newEngine;
		CurrentEngineUpdated();
	}
	
	public void CurrentEngineUpdated() {
		_currentEngineChangedPublisher.Publish(_stateService.CurrentAgent.Engine);
	}

	public void Dispose() {
		_currentAgentChangedPublisher.Dispose();
		
		GC.SuppressFinalize(this);
	}
}