namespace ZZZDmgCalculator.Components.Main;

using Microsoft.AspNetCore.Components;
using Models.Enum;
using ZZZ.ApiModels;

public partial class SkillLevelSelector {
	Skills[] _skills = [Skills.Basic, Skills.Dodge, Skills.Assist, Skills.Ex, Skills.Ultimate];
	
	[Parameter]
	public int[] SkillLevels { get; set; } = [];

	[Parameter]
	public CoreSkills CoreLevel { get; set; }

	[Parameter]
	public EventCallback<(int, int)> SkillLevelChanged { get; set; }
	
	[Parameter]
	public EventCallback<CoreSkills> CoreLevelChanged { get; set; }
	
}