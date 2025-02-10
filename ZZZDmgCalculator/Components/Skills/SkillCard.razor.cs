using Microsoft.AspNetCore.Components;

namespace ZZZDmgCalculator.Components.Skills;

using Models.Info;
using Models.State;
using ZZZ.ApiModels;

public partial class SkillCard {
	
	[Parameter]
	public AgentState Agent { get; set; } = null!;
	
}