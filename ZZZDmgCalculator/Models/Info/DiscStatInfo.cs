namespace ZZZDmgCalculator.Models.Info;

using ZZZ.ApiModels;

public class DiscStatInfo : BaseInfo<AgentStats> {

	public int[]? MainDiscs { get; init; }

	public double[][]? MainScales { get; init; }

	public double[]? SubScales { get; init; }

	public required StatModifier Buff { get; init; }
	
	public bool IsMain => MainScales is not null;
	
	public bool IsSub => SubScales is not null;
}