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

	public IEnumerable<BuffState> SharedBuffs => Team.Agents
		.Where(a => a is not null && a != Agent)
		.SelectMany(a => a!.Buffs).Where(b => b.Shared);

	public IEnumerable<BuffState> DiscBuffs => ((IBuffContainer)Agent).Children
		.Where(c => c.Source == BuffSource.Disc)
		.SelectMany(c => c.Buffs);
}