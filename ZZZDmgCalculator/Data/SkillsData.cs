namespace ZZZDmgCalculator.Data;

using Models.Info;
using ZZZ.ApiModels;

[UrlTemplate("icons/skills/Icon_{Icon}.webp")]
[InfoData<Skills>]
public static class SkillsData {
	public readonly static Dictionary<Skills, BaseInfo> Data = new()
	{
		[Skills.Basic] = new()
		{
			Id = nameof(Skills.Basic),
			Icon = "Basic_Attack",
		},
		[Skills.Dodge] = new()
		{
			Id = nameof(Skills.Dodge),
			Icon = "Dodge",
		},
		[Skills.Assist] = new()
		{
			Id = nameof(Skills.Assist),
			Icon = "Assist_Attack",
		},
		[Skills.Special] = new()
		{
			Id = nameof(Skills.Special),
			Icon = "Special_Attack",
		},
		[Skills.Ultimate] = new()
		{
			Id = nameof(Skills.Ultimate),
			Icon = "Ultimate_Colored",
		},
		[Skills.Chain] = new()
		{
			Id = nameof(Skills.Chain),
			Icon = "QTE",
		},
		[Skills.Ex] = new()
		{
			Id = nameof(Skills.Ex),
			Icon = "EX_Special_Attack",
		},
		[Skills.Dash] = new()
		{
			Id = nameof(Skills.Dash),
			Icon = "Dodge",
		},
		[Skills.Quick] = new()
		{
			Id = nameof(Skills.Quick),
			Icon = "Assist_Attack",
		},
		[Skills.Core] = new()
		{
			Id = nameof(Skills.Core),
			Icon = "Core_Skill_Empty",
		},
		[Skills.Additional] = new()
		{
			Id = nameof(Skills.Additional),
			Icon = "Core_Skill_Empty",
		},
	};
}