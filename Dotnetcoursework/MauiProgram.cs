using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using Dotnetcoursework.Services;

namespace Dotnetcoursework
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            // Add Blazor WebView support
            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            // Enable developer tools in debug mode
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            // Register services
            builder.Services.AddScoped<DebtDb>(); // Scoped to ensure a single instance per request

            return builder.Build();
        }
    }
}
