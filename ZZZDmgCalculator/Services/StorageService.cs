namespace ZZZDmgCalculator.Services;

using System.Text.Json;
using System.Text.Json.Serialization;
using Blazored.LocalStorage;
using Models.Json;
using Models.Json.Saves;
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
		
		
		var buffModel = state.CurrentSetup.Agents.Select(BuffSerializer.StateToModel).ToArray();	
		
		// save buffs
		await Local.SetItemAsStringAsync($"{StateKey}.Buffs", JsonSerializer.Serialize(buffModel, Options));
		
		// save current agent index
		await Local.SetItemAsync($"{StateKey}.CurrentAgentIndex", state.CurrentAgentIndex);
		
		// save current enemy
		await Local.SetItemAsStringAsync($"{StateKey}.Enemy", JsonSerializer.Serialize(SetupSerializer.EnemyToModel(state.CurrentSetup.Enemy), Options));
	}
	
	public async Task LoadState() {
		// load model
		var agentModel = await Local.GetItemAsStringAsync($"{StateKey}.Agents");
		var setup = new SetupState();

		var enemyModel = await Local.GetItemAsStringAsync($"{StateKey}.Enemy");
		if (enemyModel != null) {
			var enemy = JsonSerializer.Deserialize<SavedEnemy>(enemyModel, Options);
			if (enemy != null) {
				SetupSerializer.ModelToEnemy(enemy, setup.Enemy);
			}
		}
		
		var buffModel = await Local.GetItemAsStringAsync($"{StateKey}.Buffs");
		var buffs = new SavedBuff[3][];
		if (buffModel != null) {
			buffs = JsonSerializer.Deserialize<SavedBuff[][]>(buffModel, Options);
		}
		
		
		if (agentModel != null) {
			var agents = JsonSerializer.Deserialize<Agent?[]>(agentModel, Options);
			if (agents != null) {
				for (int i = 0; i < 3; i++)
				{
					setup[i] = AgentSerializer.ModelToState(agents[i], info);
					if (buffs?[i] != null)
					{
						 BuffSerializer.ModelToState(buffs[i], setup[i]);
					}
					setup[i]?.UpdateAllStats();
				}
				state.CurrentSetup = setup;
			}
		}
		
		// load current agent index
		var currentAgentIndex = await Local.GetItemAsync<int>($"{StateKey}.CurrentAgentIndex");
		state.CurrentAgentIndex = currentAgentIndex;
		
		setup.Enemy.UpdateAllStats();
		// update all agents
		foreach (var agentState in setup.Agents)
		{
			agentState?.UpdateAllStats();
			agentState?.CheckAbilityBuffs();
		}
		
		notifier.CurrentAgentChanged();
	}
}