using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using Ovb3M7Db.Client;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddRadzenComponents();
builder.Services.AddRadzenCookieThemeService(options =>
{
    options.Name = "Ovb3M7DbTheme";
    options.Duration = TimeSpan.FromDays(365);
});
builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<Ovb3M7Db.Client.AppDbService>();
builder.Services.AddAuthorizationCore();
builder.Services.AddHttpClient("Ovb3M7Db.Server", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Ovb3M7Db.Server"));
builder.Services.AddScoped<Ovb3M7Db.Client.SecurityService>();
builder.Services.AddScoped<AuthenticationStateProvider, Ovb3M7Db.Client.ApplicationAuthenticationStateProvider>();
var host = builder.Build();
await host.RunAsync();