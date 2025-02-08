namespace ZZZDmgCalculator.Components.Setup;

using Microsoft.AspNetCore.Components;
using Models.Abstractions;
using Models.Enum;
using Models.State;

public partial class BuffSetup {
	[Parameter]
	public SetupState Team { get; set; } = null!;

	[Parameter]
	public AgentState Agent { get; set; } = null!;

	IEnumerable<BuffState> _engineBuffs = null!;
	IEnumerable<BuffState> _discBuffs = null!;
	IEnumerable<BuffState> _sharedBuffs = null!;
	IEnumerable<BuffState> _agentBuffs = null!;

	protected override void OnParametersSet() {
		base.OnParametersSet();
		IBuffContainer container = Agent;
		_agentBuffs = container.Buffs;
		_engineBuffs = container.Children.Where(c => c.Source == BuffSource.Engine).SelectMany(c => c.Buffs);
		_discBuffs = container.Children.Where(c => c.Source == BuffSource.Disc).SelectMany(c => c.Buffs);
		_sharedBuffs = Team.AllBuffs.Except(container.SelfBuffs);
	}
}