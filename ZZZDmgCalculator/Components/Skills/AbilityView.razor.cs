namespace ZZZDmgCalculator.Components.Skills;

using Microsoft.AspNetCore.Components;
using Models.State;

public partial class AbilityView {
	[Parameter]
	public AbilityState Ability { get; set; } = null!;
}