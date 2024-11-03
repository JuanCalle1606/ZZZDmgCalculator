namespace ZZZDmgCalculator.Models.Json;

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
			Discs = state.Discs.Select(DiscSerializer.StateToModel).Where(d => d is not null).Cast<Agent.Disc>().ToArray(),
			Skills = SkillSerializer.StateToModel(state)
		};
	}
}