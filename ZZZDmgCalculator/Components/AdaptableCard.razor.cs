namespace ZZZDmgCalculator.Components;

using Microsoft.AspNetCore.Components;
using Services;

public partial class AdaptableCard {
	[CascadingParameter]
	public AdaptableCards? Parent { get; set; }

	[Parameter]
	public RenderFragment? ChildContent { get; set; }
	
	[Parameter]
	public string TabText { get; set; } = string.Empty;

	string CardStyle => $"width: {Parent!.CardWith}px; overflow: hidden scroll;";

	protected override void OnBrowserResize(BrowserDimension dimension) => StateHasChanged();
}