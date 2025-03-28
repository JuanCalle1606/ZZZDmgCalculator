namespace ZZZDmgCalculator.Services;

using System.Threading.Tasks;
using MessagePipe;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

public class BrowserService(IJSRuntime js, IBufferedAsyncPublisher<BrowserDimension> publisher) {

	public BrowserDimension Dimensions { get; private set; }

	bool _initialized;

	[JSInvokable]
	public async Task OnResizeEvent(int width, int height) {
		if (Dimensions.Width == width && Dimensions.Height == height) return;

		Dimensions = new() { Width = width, Height = height };
		await publisher.PublishAsync(Dimensions);
	}

	public async Task Init() {
		if (_initialized) return;
		_initialized = true;
		Dimensions = await js.InvokeAsync<BrowserDimension>("getDimensions");
		await publisher.PublishAsync(Dimensions);
		await js.InvokeVoidAsync("registerViewportChangeCallback", DotNetObjectReference.Create(this));
	}

	public async Task<BrowserDimension> GetElementDimensionAsync(ElementReference container) {
		return await js.InvokeAsync<BrowserDimension>("getElementDimensions", container);
	}
}

public struct BrowserDimension {
	public int Width { get; set; }

	public int Height { get; set; }
}