namespace ZZZDmgCalculator.Services;

using System.Text.Json;
using System.Text.Json.Serialization;
using Blazored.LocalStorage;
using Models.Json;
using Models.State;
using ZZZ.ApiModels.Responses;

public class StorageService(ILocalStorageService localStorage, StateService state, InfoService info, NotifierService notifier) {
	
	const string StateKey = "Setup";
	
	readonly static JsonSerializerOptions Options = new()
	{
		WriteIndented = false,
		Converters =
		{
			new JsonStringEnumConverter()
		}
	};
	
	public ILocalStorageService Local{ get; } = localStorage;

	public async Task SaveState() {
		// get model to save
		var agentModel = state.CurrentSetup.Agents.Select(AgentSerializer.StateToModel).ToArray();	
		// save model
		await Local.SetItemAsStringAsync($"{StateKey}.Agents", JsonSerializer.Serialize(agentModel, Options));
		
		// save current agent index
		await Local.SetItemAsync($"{StateKey}.CurrentAgentIndex", state.CurrentAgentIndex);
	}
	
	public async Task LoadState() {
		// load model
		var agentModel = await Local.GetItemAsStringAsync($"{StateKey}.Agents");
		if (agentModel != null) {
			var agents = JsonSerializer.Deserialize<Agent?[]>(agentModel, Options);
			if (agents != null) {
				var setup = new SetupState();
				for (int i = 0; i < 3; i++)
				{
					setup[i] = AgentSerializer.ModelToState(agents[i], info);
				}
				state.CurrentSetup = setup;
			}
		}
		
		// load current agent index
		var currentAgentIndex = await Local.GetItemAsync<int>($"{StateKey}.CurrentAgentIndex");
		state.CurrentAgentIndex = currentAgentIndex;
		
		notifier.CurrentAgentChanged();
	}
}