namespace ZZZDmgCalculator.Models.Json;

using State;
using ZZZ.ApiModels;
using ZZZ.ApiModels.Responses;

public static class SkillSerializer {

	public readonly static Skills[] AbilitySkills = [Skills.Basic, Skills.Dodge, Skills.Assist, Skills.Special, Skills.Ultimate];

	public static List<Agent.Skill> StateToModel(AgentState state) {
		var dev = AbilitySkills.Select(skill => new Agent.Skill() { Id = skill, Title = skill.ToString(), Level = state.Skills[skill], });
		return dev.Append(new()
		{
			Id = Skills.Core,
			Title = Skills.Core.ToString(),
			Level = (int)state.CoreSkillLevel,
		}).ToList();
	}
}