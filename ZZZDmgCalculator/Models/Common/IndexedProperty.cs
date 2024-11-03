namespace ZZZDmgCalculator.Models.Common;

using System.Collections;

public class IndexedProperty<TIndex, TValue>(Func<TIndex, TValue> getFunc, Action<TIndex, TValue> setAction) {
	public TValue this[TIndex i]
	{
		get => getFunc(i);
		set => setAction(i, value);
	}
}

public class EnumerableIndexedProperty<TIndex, TValue, TEnum>(Func<TIndex, TValue> getFunc, Action<TIndex, TValue> setAction, IEnumerable<TEnum> enumerable) : IEnumerable<TEnum> {
	public TValue this[TIndex i]
	{
		get => getFunc(i);
		set => setAction(i, value);
	}
	public IEnumerator<TEnum> GetEnumerator() => enumerable.GetEnumerator();
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class EnumerableIndexedProperty<TIndex, TValue>(Func<TIndex, TValue> getFunc, Action<TIndex, TValue> setAction, IEnumerable<TValue> enumerable) : IEnumerable<TValue> {
	public TValue this[TIndex i]
	{
		get => getFunc(i);
		set => setAction(i, value);
	}
	public IEnumerator<TValue> GetEnumerator() => enumerable.GetEnumerator();
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}