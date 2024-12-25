namespace ZZZDmgCalculator.Layout;

using System.Text.Json;
using Microsoft.AspNetCore.Components.Web;
using Models.Json;
using Models.State;

public partial class MainLayout {

	async Task SaveState() {
		// Save state
		Console.WriteLine("Saving state");
		await Storage.SaveState();
		Console.WriteLine("State saved");
	}
	async Task LoadState(MouseEventArgs obj) {
		// Load state
		Console.WriteLine("Loading state");
		/*var setup = await LocalStorage.GetItemAsStringAsync("setup");
		if (setup != null)
		{
			State.CurrentSetup = JsonSerializer.Deserialize<SetupState>(setup, _jsonSerializerOptions)!;
			var currentAgentIndex = await LocalStorage.GetItemAsync<int>("currentAgentIndex");
			State.CurrentAgentIndex = currentAgentIndex;
			Notifier.CurrentAgentChanged();
		}*/
		await Storage.LoadState();

		Console.WriteLine("State loaded");
	}
}