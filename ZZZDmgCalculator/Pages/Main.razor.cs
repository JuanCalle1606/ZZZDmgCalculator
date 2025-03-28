namespace ZZZDmgCalculator.Pages;

using Extensions;
using MessagePipe;

public partial class Main {
	protected override void OnDisposableBag(DisposableBagBuilder bag) {
		Notifier.OnCurrentAgentChanged.SubscribeUpdate(this).AddTo(bag);
	}
}