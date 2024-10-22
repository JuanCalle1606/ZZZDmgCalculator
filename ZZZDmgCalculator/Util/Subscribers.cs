namespace ZZZDmgCalculator.Util;

using Components.Main;
using MessagePipe;

public static class Subscribers {
	public static IDisposable SubscribeUpdate<T>(this ISubscriber<T> subscriber, MainComponent component) {
		return subscriber.Subscribe(_ => component.Update());
	}
}