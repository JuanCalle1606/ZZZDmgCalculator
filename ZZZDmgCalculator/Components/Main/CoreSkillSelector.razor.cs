namespace ZZZDmgCalculator.Components.Main;

using Microsoft.AspNetCore.Components;
using Models.Enum;

public partial class CoreSkillSelector {
	string[] _urls = null!;

	[Parameter]
	public EventCallback<CoreSkills> ValueChanged { get; set; }

	[Parameter]
	public CoreSkills Value { get; set; }

	protected override void OnInitialized() {
		base.OnInitialized();
		_urls = Enum.GetValues<CoreSkills>().Select(c => Info[c].Url).ToArray();
	}
	
	string GetClass(int i) {
		var className = "core-skill";
		if (Value < (CoreSkills)i && i > 0)
		{
			className += " core-skill-selected";
		}
		if (Value == (CoreSkills)i)
		{
			className += " core-skill-current";
		}
		return className;
	}

	async Task ChangeValue(int i) {
		var newval = (CoreSkills)i;
		if (newval == Value)
			return;
		await ValueChanged.InvokeAsync(newval);
		Notifier.CurrentAgentChanged(); // notify to re-render all the main page, TODO: maybe only re-render things that depend on the core skill
	}
}