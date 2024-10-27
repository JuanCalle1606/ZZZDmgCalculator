namespace ZZZDmgCalculator.Components.Setup;

using Microsoft.AspNetCore.Components;
using Models.State;

public partial class BuffList {
	[Parameter]
	public IEnumerable<BuffState>? Buffs { get; set; }

	BuffState[] _buffStates = null!;

	protected override void OnParametersSet() {
		base.OnParametersSet();
		_buffStates = Buffs?.ToArray() ?? [];
	}
}