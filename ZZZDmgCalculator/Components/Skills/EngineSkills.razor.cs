using Microsoft.AspNetCore.Components;

namespace ZZZDmgCalculator.Components.Skills;

using Models.State;

public partial class EngineSkills {
	[Parameter]
	public EngineState Engine { get; set; } = null!;
}