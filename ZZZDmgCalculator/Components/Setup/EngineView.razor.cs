using Microsoft.AspNetCore.Components;

namespace ZZZDmgCalculator.Components.Setup;

using Models.State;
using Util;

public partial class EngineView {
	[Parameter]
	public EngineState Engine { get; set; } = null!;

	[Parameter]
	public EventCallback<EngineState> EngineChanged { get; set; }
	
	async Task OpenEngineDialog() {
		if (await Dialogs.OpenEngineDialog() is {} info)
		{
			await EngineChanged.InvokeAsync(info);
		}
	}
}