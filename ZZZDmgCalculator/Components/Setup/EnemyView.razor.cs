namespace ZZZDmgCalculator.Components.Setup;

using Microsoft.AspNetCore.Components;
using Models.State;

public partial class EnemyView {
	[Parameter]
	public EnemyState Enemy { get; set; } = null!;
}