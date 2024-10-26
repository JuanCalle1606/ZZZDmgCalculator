namespace ZZZDmgCalculator.Layout;

using System.Text.Json;
using Microsoft.AspNetCore.Components.Web;
using Models.Json;
using Models.State;

public partial class MainLayout {
	JsonSerializerOptions? _jsonSerializerOptions;

	protected override void OnInitialized() {
		base.OnInitialized();
		_jsonSerializerOptions = new()
		{
			Converters = { new DummyConverter(Info) }
		};
	}

	async Task SaveState() {
		// Save state
		Console.WriteLine("Saving state");
		await LocalStorage.SetItemAsStringAsync("setup", JsonSerializer.Serialize(State.CurrentSetup, _jsonSerializerOptions));
		await LocalStorage.SetItemAsync("currentAgentIndex", State.CurrentAgentIndex);
		Console.WriteLine("State saved");
	}
	async Task LoadState(MouseEventArgs obj) {
		// Load state
		Console.WriteLine("Loading state");
		var setup = await LocalStorage.GetItemAsStringAsync("setup");
		if (setup != null)
		{
			State.CurrentSetup = JsonSerializer.Deserialize<SetupState>(setup, _jsonSerializerOptions)!;
			var currentAgentIndex = await LocalStorage.GetItemAsync<int>("currentAgentIndex");
			State.CurrentAgentIndex = currentAgentIndex;
			Notifier.CurrentAgentChanged();
		}

		Console.WriteLine("State loaded");
	}
}