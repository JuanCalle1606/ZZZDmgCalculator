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
		
		var visited = await LocalStorage.GetItemAsync<bool>("Visited");
		if (!visited) {
			await LocalStorage.SetItemAsync("Visited", true);
			await LocalStorage.SetItemAsync("LastVersion", typeof(FirstTime).Assembly.GetName().Version!.ToString());
			await Dialogs.OpenAboutDialog();
		}
		else
		{
			var lastVersion = await LocalStorage.GetItemAsync<string>("LastVersion");
			if (!string.IsNullOrEmpty(lastVersion))
			{
				var lv = new Version(lastVersion);
				var cv = typeof(FirstTime).Assembly.GetName().Version!;
				if (lv < cv)
				{
					await LocalStorage.SetItemAsync("LastVersion", cv.ToString());
					await Dialogs.OpenAboutDialog();
				}
			}
		}
	}
}