namespace ZZZDmgCalculator.Components;

using Blazored.LocalStorage;
using Extensions;
using Main;
using Microsoft.AspNetCore.Components;

public class FirstTime : MainComponent {
	[Inject]
	public ILocalStorageService LocalStorage { get; set; } = null!;
	
	protected override async Task OnInitializedAsync() {
		await base.OnInitializedAsync();
		
		var visited = await LocalStorage.GetItemAsync<bool>("Visited");
		var cv = typeof(FirstTime).Assembly.GetName().Version!;
		if (!visited) {
			await LocalStorage.SetItemAsync("Visited", true);
			await Dialogs.OpenAboutDialog();
		}
		else
		{
			var lastVersion = await LocalStorage.GetItemAsync<string>("LastVersion");
			if (!string.IsNullOrEmpty(lastVersion))
			{
				var lv = new Version(lastVersion);
				if (lv < cv)
				{
					await Dialogs.OpenAboutDialog();
				}
			}
		}
		await LocalStorage.SetItemAsync("LastVersion", cv.ToString());

	}
}