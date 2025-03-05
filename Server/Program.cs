using Radzen;
using Ovb3HandPwa.Server.Components;
using Ovb3HandPwa.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// 1) Register the PokerService as a singleton (only one instance needed)
builder.Services.AddSingleton<PokerService>();

// Add services to the container.
builder.Services.AddRazorComponents()
      .AddInteractiveWebAssemblyComponents();

// If you have controllers or want to build out an API, you need them:
builder.Services.AddControllers();

// Radzen bits
builder.Services.AddRadzenComponents();
builder.Services.AddRadzenCookieThemeService(options =>
{
    options.Name = "Ovb3HandPwaTheme";
    options.Duration = TimeSpan.FromDays(365);
});

// You can also add .AddHttpClient() if you want to inject HttpClient on the server side.
// But the client side's HttpClient is configured in the Client project's Program.cs.
builder.Services.AddHttpClient();

// 2) Build and configure
var app = builder.Build();

// 3) Map minimal API endpoints for your PokerService
//    => GET /api/poker/hand returns the PokerHand string
//    => GET /api/poker/deck returns the DeckList
app.MapGet("/api/poker/hand", (PokerService service) => service.PokerHand);
app.MapGet("/api/poker/deck", (PokerService service) => service.DeckList);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // For local debugging
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

// If you have controller-based APIs
app.MapControllers();

// Serve static files (for the WASM client, CSS, JS, images, etc.)
app.UseStaticFiles();

// If you're using antiforgery tokens for forms, etc.
app.UseAntiforgery();

// This is the .NET 8 approach to map your Razor components (Server + WASM):
app.MapRazorComponents<App>()
   .AddInteractiveWebAssemblyRenderMode()
   .AddAdditionalAssemblies(typeof(Ovb3HandPwa.Client._Imports).Assembly);

// Finally, run the app
app.Run();
