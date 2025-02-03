namespace ZZZDmgCalculator.Components.Skills;

using Microsoft.AspNetCore.Components;
using Models.Info;

public partial class AbilityView {
	[Parameter]
	public AbilityInfo Ability { get; set; } = null!;
	
	[Parameter]
	public int Scale { get; set; }
}