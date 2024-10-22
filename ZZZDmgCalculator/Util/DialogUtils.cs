namespace ZZZDmgCalculator.Util;

using Dialogs;
using Models.State;
using Radzen;

public static class DialogUtils {
	public async static Task<AgentState?> OpenAgentDialog(this DialogService dialogs) {
		object d = await dialogs.OpenAsync<ChooseAgentDialog>("AgentSelection", null, new()
		{
			Width = "950px",
			Height = "750px",
			ShowTitle = false,
			AutoFocusFirstElement = false,
			Style = "max-width: 100%"
		});
		return (AgentState?)d;
	}
	
	public async static Task<EngineState?> OpenEngineDialog(this DialogService dialogs) {
		object d = await dialogs.OpenAsync<ChooseEngineDialog>("EngineSelection", null, new()
		{
			Width = "950px",
			Height = "750px",
			ShowTitle = false,
			AutoFocusFirstElement = false,
			Style = "max-width: 100%"
		});
		return (EngineState?)d;
	}

	public async static Task OpenAboutDialog(this DialogService dialogs) {
		await dialogs.OpenAsync<AboutDialog>("About", null, new()
		{
			Width = "650px",
			Height = "450px",
			ShowTitle = false,
			AutoFocusFirstElement = false,
			Style = "max-width: 100%",
			CloseDialogOnEsc = true,
			CloseDialogOnOverlayClick = true
		});
	}
}