namespace ZZZDmgCalculator.Util;

using Models.Info;

public class SingleList <T> : List<T> {
	public static implicit operator SingleList <T>(T d) => [d];
}