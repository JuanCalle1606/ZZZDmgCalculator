namespace ZZZDmgCalculator.Models.Json;

using Services;
using State;
using ZZZ.ApiModels.Responses;

public static class AgentSerializer {

	public static Agent? StateToModel(AgentState? state) {
		if (state is null) return null;
		return new()
		{
			Id = state.Info.Uid,
			Ascension = state.Ascension,
			Cinema = state.Cinema,
			Name = state.Info.DisplayName,
			Engine = EngineSerializer.StateToModel(state.Engine),
			Discs = state.Discs.Select(DiscSerializer.StateToModel).Where(d => d is not null).Cast<Agent.Disc>().ToList(),
			Skills = SkillSerializer.StateToModel(state)
		};
	}
	public static AgentState? ModelToState(Agent? agent, InfoService info) {
		if (agent is null) return null;
		var state = new AgentState(info[agent.Id])
		{
			Loading = true,
			Ascension = agent.Ascension,
			Cinema = agent.Cinema,
			Engine = EngineSerializer.ModelToState(agent.Engine, info)
		};

		DiscSerializer.ModelToState(agent.Discs, state, info);
		SkillSerializer.ModelToState(agent.Skills, state);
		state.Loading = false;
		state.UpdateAllStats();
		return state;
	}
}