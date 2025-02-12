namespace ZZZDmgCalculator.Models.Json;

using Abstractions;
using Enum;
using Saves;
using State;

public static class BuffSerializer {

	public static SavedBuff[] StateToModel(IBuffContainer? arg) {
		if (arg == null)
		{
			return [];
		}

		return arg.SelfBuffs.Select(StateToModel).Where(a => a.Stacks != 0 || a.Enabled).ToArray();
	}
	static SavedBuff StateToModel(BuffState buff) {
		return new()
		{
			Id = buff.Info.Id,
			Stacks = buff.Stacks,
			Enabled = buff.Enabled,
			// TODO: Add the applied to agent
		};
	}
	public static void ModelToState(SavedBuff[] buff, IBuffContainer? agentState) {
		if (agentState == null) return;

		foreach (var buffModel in buff)
		{
			var buffState = agentState.SelfBuffs.FirstOrDefault(a => a.Info.Id == buffModel.Id);
			if (buffState == null) continue;

			if (buffState.Info.Type is BuffTrigger.Stack)
				buffState.Stacks = buffModel.Stacks;
			else
				buffState.Enabled = buffModel.Enabled;
		}
		foreach (var agentBuff in agentState.SelfBuffs)
		{
			agentBuff.DependencyChecker?.CheckBuffDependencies(agentBuff);
		}
	}
}