using Microsoft.AspNetCore.Components;

namespace ZZZDmgCalculator.Components.Skills;

using Models.Info;
using Models.State;
using ZZZ.ApiModels;

public partial class SkillCard {
	
	List<IGrouping<Skills, AbilityInfo>> _groups = null!;

	[Parameter]
	public AgentState Agent { get; set; } = null!;

	protected override void OnParametersSet() {
		_groups = Agent.Info.Abilities.Where(a=>a.Skills.Any()).GroupBy(a => a.Category).ToList();
	}
}