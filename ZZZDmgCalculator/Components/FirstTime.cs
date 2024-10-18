namespace ZZZDmgCalculator.Components;

using Blazored.LocalStorage;
using Main;
using Microsoft.AspNetCore.Components;
using Util;

public class FirstTime : MainComponent {
	[Inject]
	public ILocalStorageService LocalStorage { get; set; } = null!;
	
	protected override async Task OnInitializedAsync() {
		await base.OnInitializedAsync();
		
		var firstTime = await LocalStorage.GetItemAsync<bool>("Visited");
		if (!firstTime) {
			await LocalStorage.SetItemAsync("Visited", true);
			await LocalStorage.SetItemAsync("LastVersion", typeof(FirstTime).Assembly.GetName().Version!.ToString());
			await Dialogs.OpenAboutDialog();
		}
	}
}