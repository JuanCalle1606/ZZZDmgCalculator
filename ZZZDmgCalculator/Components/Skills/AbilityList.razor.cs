namespace ZZZDmgCalculator.Components.Skills;

using Microsoft.AspNetCore.Components;
using Models.Info;
using Models.State;
using ZZZ.ApiModels;

public partial class AbilityList {
	[Parameter]
	public Skills Category { get; set; }
	
	[Parameter]
	public IEnumerable<AbilityState> Abilities { get; set; } = null!;
	
	[Parameter]
	public AgentState Agent { get; set; } = null!;
}