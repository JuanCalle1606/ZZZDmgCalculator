namespace ZZZDmgCalculator.Components;

using Microsoft.AspNetCore.Components;
using Services;

public partial class AdaptableCards {

	public int CardWith { get; private set; }

	public bool Phone { get; private set; }

	[Parameter]
	public RenderFragment ChildContent { get; set; } = null!;
	
	protected override void OnBrowserResize(BrowserDimension dimension) {
		const int widthMax = 475;
		const int widthMin = 375;
		CardWith = dimension.Width switch
		{
			> 1900 => widthMax,
			< 1275 => widthMin,
			_ => (dimension.Width - 1275) * (widthMax - widthMin) / (1900 - 1275) + widthMin
		};

		Phone = dimension.Width < 576;

		StateHasChanged(); 
	}
}