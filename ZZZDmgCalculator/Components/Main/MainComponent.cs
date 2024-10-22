namespace ZZZDmgCalculator.Components.Main;

using System.Diagnostics.CodeAnalysis;
using MessagePipe;
using Microsoft.AspNetCore.Components;
using Radzen;
using Services;

public abstract class MainComponent : ComponentBase, IDisposable {

	IDisposable _disposable = null!;

	[Inject]
	protected BrowserService Browser { get; private set; } = null!;

	[Inject]
	protected DialogService Dialogs { get; set; } = null!;
	
	[Inject]
	protected LangService Lang { get; private set; } = null!;
	
	[Inject]
	protected InfoService Info { get; private set; } = null!;
	
	[Inject]
	protected StateService State { get; private set; } = null!;
	
	[Inject]
	protected NotifierService Notifier { get; private set; } = null!;

	[Inject]
	IBufferedAsyncSubscriber<BrowserDimension> ResizeSubscriber { get; set; } = null!;

	protected override async Task OnInitializedAsync() {
		var bag = DisposableBag.CreateBuilder();
		(await ResizeSubscriber.SubscribeAsync(ResizeHandler)).AddTo(bag);
		
		OnDisposableBag(bag);
		_disposable = bag.Build();
	}

	[SuppressMessage("ReSharper", "MethodHasAsyncOverload")]
	async ValueTask ResizeHandler(BrowserDimension dimension, CancellationToken token) {
		OnBrowserResize(dimension);
		await OnBrowserResizeAsync(dimension);
	}

	public void Update() => StateHasChanged();

	protected bool StateHasChanged(ref int state, int limit) {
		if ((Browser.Dimensions.Width < limit && state >= limit) ||
		    (Browser.Dimensions.Width >= limit && state < limit))
		{
			state = Browser.Dimensions.Width;
			StateHasChanged();
		}

		return Browser.Dimensions.Width < limit;
	}

	protected virtual Task OnBrowserResizeAsync(BrowserDimension dimension) {
		
		return Task.CompletedTask;
	}
	
	protected virtual void OnBrowserResize(BrowserDimension dimension) {}

	protected virtual void OnDisposableBag(DisposableBagBuilder bag) {}

	public void Dispose() {
		_disposable.Dispose();
		GC.SuppressFinalize(this);
	}
}