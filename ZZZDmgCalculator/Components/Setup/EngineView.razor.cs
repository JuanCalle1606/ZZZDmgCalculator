using Microsoft.AspNetCore.Components;

namespace ZZZDmgCalculator.Components.Setup;

using Models.Enum;
using Models.State;
using Pages;
using Util;

public partial class EngineView {
	[Parameter]
	public EngineState Engine { get; set; } = null!;

	[Parameter]
	public EventCallback<EngineState> EngineChanged { get; set; }

	[CascadingParameter]
	public Main MainPage { get; set; } = null!;
	
	async Task OpenEngineDialog() {
		if (await Dialogs.OpenEngineDialog() is {} info)
		{
			await EngineChanged.InvokeAsync(info);
			MainPage.FullUpdate();
		}
	}

	void AscencionChanged(AscensionState ascension) {
		Engine.Ascension = ascension;
		State.CurrentAgent.UpdateAll();
		MainPage.FullUpdate();
	}
}