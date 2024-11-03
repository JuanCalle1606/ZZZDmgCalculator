namespace ZZZDmgCalculator.Components.Main;

using Microsoft.AspNetCore.Components;
using Models.Common;
using Models.Enum;
using Models.Json;
using ZZZ.ApiModels;

public partial class SkillLevelSelector {
	Skills[] _skills = SkillSerializer.AbilitySkills;

	[Parameter]
	public IndexedProperty<Skills, int> SkillLevels { get; set; } = null!;

	[Parameter]
	public CoreSkills CoreLevel { get; set; }

	[Parameter]
	public EventCallback<(Skills, int)> SkillLevelChanged { get; set; }
	
	[Parameter]
	public EventCallback<CoreSkills> CoreLevelChanged { get; set; }
	
}