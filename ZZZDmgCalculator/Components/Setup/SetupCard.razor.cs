namespace ZZZDmgCalculator.Components.Setup;

using Microsoft.AspNetCore.Components;
using Models.State;

public partial class SetupCard {
	[Parameter]
	public SetupState TeamState { get; set; } = null!;
}