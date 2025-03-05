using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddRadzenComponents();
builder.Services.AddRadzenCookieThemeService(options =>
{
    options.Name = "Ovb3HandPwaTheme";
    options.Duration = TimeSpan.FromDays(365);
});
// The KEY line:
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

await builder.Build().RunAsync();