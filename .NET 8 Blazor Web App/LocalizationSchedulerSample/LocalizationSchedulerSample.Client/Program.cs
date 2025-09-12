using LocalizationSchedulerSample.Client;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using Syncfusion.Blazor;
using System.Globalization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddSyncfusionBlazor();

// Register your custom localizer for the client-side application
builder.Services.AddSingleton<ISyncfusionStringLocalizer, SyncfusionLocalizer>();

var host = builder.Build();

// Set the culture of the application.
var jsInterop = host.Services.GetRequiredService<IJSRuntime>();
var result = await jsInterop.InvokeAsync<string>("cultureInfo.get");

CultureInfo culture;
if (result != null)
{
    culture = new CultureInfo(result);
}
else
{
    // Default to English if no culture is set.
    culture = new CultureInfo("de");
    await jsInterop.InvokeVoidAsync("cultureInfo.set", "de");
}

CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

await host.RunAsync();
