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

	List<BuffState> _engineBuffs = null!;
	List<BuffState> _discBuffs = null!;
	List<BuffState> _sharedBuffs = null!;
	List<BuffState> _agentBuffs = null!;

	protected override void OnInitialized() {
		base.OnInitialized();
		IBuffContainer container = Agent;
		_agentBuffs = container.Buffs;
		_engineBuffs = container.Children.Where(c => c.Source == BuffSource.Engine).SelectMany(c => c.Buffs).ToList();
		_discBuffs = container.Children.Where(c => c.Source == BuffSource.Disc).SelectMany(c => c.Buffs).ToList();
		_sharedBuffs = Team.AllBuffs.Except(container.SelfBuffs).ToList();
	}
}