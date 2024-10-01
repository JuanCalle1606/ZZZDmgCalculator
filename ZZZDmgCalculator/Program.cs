using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;
using ZZZDmgCalculator;
using ZZZDmgCalculator.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<LangService>();
builder.Services.AddSingleton<InfoService>();
builder.Services.AddFluentUIComponents();

var app = builder.Build();
app.Services.GetService<InfoService>()!.LoadAll();
await app.RunAsync();
