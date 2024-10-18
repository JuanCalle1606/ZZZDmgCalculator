namespace ZZZDmgCalculator.Components;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

public class DebugOnly : ComponentBase {

	[Parameter]
	public RenderFragment? ChildContent { get; set; }
	
	protected override void BuildRenderTree(RenderTreeBuilder builder) { base.BuildRenderTree(builder);
#if DEBUG
			builder.AddContent(0, ChildContent);
#endif
		
	}

}