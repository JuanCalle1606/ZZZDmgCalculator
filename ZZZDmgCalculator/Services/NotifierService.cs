namespace ZZZDmgCalculator.Services;

using MessagePipe;
using Models.State;

public class NotifierService : IDisposable {
	
	readonly StateService _stateService;

	readonly IDisposablePublisher<AgentState> _currentAgentChangedPublisher;
	public ISubscriber<AgentState> OnCurrentAgentChanged { get; }
	
	readonly IDisposablePublisher<EngineState?> _currentEngineChangedPublisher;
	public ISubscriber<EngineState?> OnCurrentEngineChanged { get; }
	
	readonly IDisposablePublisher<KeyValuePair<int, DiscState?>> _currentDiscChangedPublisher;
	public ISubscriber<KeyValuePair<int, DiscState?>> OnCurrentDiscChanged { get; }

	public NotifierService(EventFactory eventFactory, StateService stateService) {
		_stateService = stateService;
		(_currentAgentChangedPublisher, OnCurrentAgentChanged) = eventFactory.CreateEvent<AgentState>();
		(_currentEngineChangedPublisher, OnCurrentEngineChanged) = eventFactory.CreateEvent<EngineState?>();
		(_currentDiscChangedPublisher, OnCurrentDiscChanged) = eventFactory.CreateEvent<KeyValuePair<int, DiscState?>>();
	}
	
	public void SwapCurrentAgent(AgentState newAgent) {
		_stateService.CurrentAgent = newAgent;
		
		_currentAgentChangedPublisher.Publish(_stateService.CurrentAgent);
	}

	public void SwapCurrentEngine(EngineState? newEngine) {
		_stateService.CurrentAgent.Engine = newEngine;
		CurrentEngineUpdated();
	}
	
	public void CurrentEngineUpdated() {
		_currentEngineChangedPublisher.Publish(_stateService.CurrentAgent.Engine);
	}

	public void Dispose() {
		_currentAgentChangedPublisher.Dispose();
		_currentEngineChangedPublisher.Dispose();
		_currentDiscChangedPublisher.Dispose();
		
		GC.SuppressFinalize(this);
	}
	
	public void SwapCurrentDisc(int i, DiscState? info) {
		_stateService.CurrentAgent.SetDisc(info, i);
		CurrentDiscUpdated(i);
	}
	
	public void CurrentDiscUpdated(int i) {
		_currentDiscChangedPublisher.Publish(new(i, _stateService.CurrentAgent.Discs[i]));
	}
}