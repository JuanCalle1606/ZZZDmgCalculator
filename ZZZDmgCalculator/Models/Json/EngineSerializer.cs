namespace ZZZDmgCalculator.Models.Json;

using Services;
using State;
using ZZZ.ApiModels.Responses;
using static ZZZ.ApiModels.AgentStats;

public static class EngineSerializer { 

	public static Agent.Weapon? StateToModel(EngineState? stateEngine) {
		if (stateEngine is null) return null;
		return new()
		{
			Id = stateEngine.Info.Uid,
			Ascension = stateEngine.Ascension,
			Name = stateEngine.Info.DisplayName,
			Refinement = stateEngine.Refinement,
			MainStat = new()
			{
				Id = Atk, Value = "0",
			},SubStat = new()
			{
				Id = Atk, Value = "0",
			}
		};
	}
	
	public static EngineState? ModelToState(Agent.Weapon? engine, InfoService info) {
		if (engine is null) return null;
		var state = new EngineState(info[engine.Id])
		{
			Ascension = engine.Ascension,
			Refinement = engine.Refinement
		};
		
		return state;
	}
}