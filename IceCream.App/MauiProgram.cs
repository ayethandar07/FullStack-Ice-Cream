using CommunityToolkit.Maui;
using IceCream.App.Pages;
using IceCream.App.Services;
using IceCream.App.ViewModels;
using Microsoft.Extensions.Logging;
using Refit;

#if ANDROID
using System.Net.Security;
using Xamarin.Android.Net;
#endif

namespace IceCream.App;

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
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .UseMauiCommunityToolkit();

#if DEBUG
		builder.Logging.AddDebug();
#endif

        builder.Services.AddTransient<AuthViewModel>()
                        .AddTransient<SignupPage>()
                        .AddTransient<SigninPage>();

        builder.Services.AddSingleton<AuthService>();
        builder.Services.AddTransient<OnBoardingPage>();

        builder.Services.AddSingleton<HomeViewModel>()
                        .AddSingleton<HomePage>();

        builder.Services.AddTransient<DetailsViewModel>()
                        .AddTransient<DetailsPage>();

        ConfigureRefit(builder.Services);

        return builder.Build();
    }

    private static void ConfigureRefit(IServiceCollection services)
    {
        var refitSettings = new RefitSettings
        {
            HttpMessageHandlerFactory = () =>
            {
#if ANDROID
                return new AndroidMessageHandler
                {
                    ServerCertificateCustomValidationCallback = (httpRequestMessage, certificate, chain, sslPolicyErrors) =>
                    {
                        return certificate?.Issuer == "CN=localhost" || sslPolicyErrors == SslPolicyErrors.None;
                    }
                };
#endif
                return null;
            }

        };

        services.AddRefitClient<IAuthApi>(refitSettings)
            .ConfigureHttpClient(SetHttpClient);

        services.AddRefitClient<IIcecreamApi>(refitSettings)
            .ConfigureHttpClient(SetHttpClient);

        static void SetHttpClient(HttpClient httpClient)
        {
            var baseUrl = DeviceInfo.Platform == DevicePlatform.Android
                                ? "https://10.0.2.2:7274"
                                : "https://localhost:7274";

            if (DeviceInfo.DeviceType == DeviceType.Physical)
            {
                baseUrl = "https://g899m819-7274.inc1.devtunnels.ms";
            }

            httpClient.BaseAddress = new Uri(baseUrl);
        }
    }
}
