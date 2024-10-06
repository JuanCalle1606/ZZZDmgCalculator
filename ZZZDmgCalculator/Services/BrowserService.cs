namespace ZZZDmgCalculator.Services;

using Microsoft.JSInterop;
using System.Threading.Tasks;
using MessagePipe;

public class BrowserService(IJSRuntime js, IAsyncPublisher<BrowserDimension> publisher) {

	public BrowserDimension Dimensions { get; private set; }

	bool _initialized;
	
	public async Task<BrowserDimension> GetDimensionSafe() {
		if (Dimensions is { Width: 0, Height: 0 })
			Dimensions = await js.InvokeAsync<BrowserDimension>("getDimensions");
		return Dimensions;
	}

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

}

public struct BrowserDimension {
	public int Width { get; set; }

	public int Height { get; set; }
}