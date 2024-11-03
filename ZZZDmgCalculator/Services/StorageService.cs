namespace ZZZDmgCalculator.Services;

using System.Text.Json;
using System.Text.Json.Serialization;
using Blazored.LocalStorage;
using Models.Json;

public class StorageService(ILocalStorageService localStorage, StateService state, InfoService info) {
	
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
	}
}