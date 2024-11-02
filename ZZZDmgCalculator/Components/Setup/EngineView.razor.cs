using Microsoft.AspNetCore.Components;

namespace ZZZDmgCalculator.Components.Setup;

using Models.Enum;
using Models.State;
using Pages;
using Extensions;

public partial class EngineView {
	[Parameter]
	public EngineState Engine { get; set; } = null!;

	[CascadingParameter]
	public Main MainPage { get; set; } = null!;
	
	async Task OpenEngineDialog() {
		if (await Dialogs.OpenEngineDialog() is {} info)
		{
			Notifier.SwapCurrentEngine(info);
		}
	}

	void RefinementChanged(int refinement) {
		Engine.Refinement = refinement;
		State.CurrentAgent!.UpdateAllStats();
		Notifier.CurrentEngineUpdated();
	}
	
	void AscensionChanged(AscensionState ascension) {
		Engine.Ascension = ascension;
		State.CurrentAgent!.UpdateAllStats();
		Notifier.CurrentEngineUpdated();
	}
	
	void RemoveEngine() {
		Notifier.SwapCurrentEngine(null);
	}
}