using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using ZZZDmgCalculator;
using ZZZDmgCalculator.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddSingleton(_ => new HttpClient { BaseAddress = new(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<LangService>();
builder.Services.AddSingleton<InfoService>();
builder.Services.AddSingleton<BrowserService>();
builder.Services.AddSingleton<StateService>();
builder.Services.AddRadzenComponents();
builder.Services.AddMessagePipe();
builder.Services.AddBlazoredLocalStorageAsSingleton();

var app = builder.Build();
app.Services.GetService<InfoService>()!.LoadAll();
await app.RunAsync();
