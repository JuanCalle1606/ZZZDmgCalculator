namespace ZZZDmgCalculator.Models.Json;

using Services;
using State;
using ZZZ.ApiModels.Responses;

public static class EngineSerializer {

	public static Agent.Weapon? StateToModel(EngineState? stateEngine) {
		if (stateEngine is null) return null;
		return new()
		{
			Id = stateEngine.Info.Uid,
			Ascension = stateEngine.Ascension,
			Name = stateEngine.Info.DisplayName,
			Refinement = stateEngine.Refinement
		};
	}
	public static EngineState? ModelToState(Agent.Weapon? agentEngine, InfoService info) {
		throw new NotImplementedException();
	}
}