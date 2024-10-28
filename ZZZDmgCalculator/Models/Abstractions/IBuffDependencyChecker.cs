namespace ZZZDmgCalculator.Models.Abstractions;

using State;

public interface IBuffDependencyChecker {
	public void CheckBuffDependencies(BuffState state);
}