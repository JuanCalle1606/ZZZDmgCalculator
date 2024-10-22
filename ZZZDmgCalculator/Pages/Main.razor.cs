namespace ZZZDmgCalculator.Pages;

using MessagePipe;
using Util;

public partial class Main {
	protected override void OnDisposableBag(DisposableBagBuilder bag) {
		Notifier.OnCurrentAgentChanged.SubscribeUpdate(this).AddTo(bag);
	}
}