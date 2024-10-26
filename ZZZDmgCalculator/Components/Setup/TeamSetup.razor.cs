using Microsoft.AspNetCore.Components;

namespace ZZZDmgCalculator.Components.Setup;

using Models.State;

public partial class TeamSetup {
	[Parameter]
	public SetupState Team { get; set; } = null!;
}