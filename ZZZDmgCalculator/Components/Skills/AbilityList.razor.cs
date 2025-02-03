namespace ZZZDmgCalculator.Components.Skills;

using Microsoft.AspNetCore.Components;
using Models.Info;
using Models.State;
using ZZZ.ApiModels;

public partial class AbilityList {
	int _skillLevel;
	
	[Parameter]
	public Skills Category { get; set; }
	
	[Parameter]
	public IEnumerable<AbilityInfo> Abilities { get; set; } = null!;
	
	[Parameter]
	public AgentState Agent { get; set; } = null!;

	protected override void OnParametersSet() {
		_skillLevel = Agent.Skills[Category] - 1;
		if (Agent.Cinema > 2) _skillLevel += 2;
		if (Agent.Cinema > 4) _skillLevel += 2;
	}
}