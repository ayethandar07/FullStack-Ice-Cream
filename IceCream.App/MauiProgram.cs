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

namespace IceCream.App
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .UseMauiCommunityToolkit();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddTransient<AuthViewModel>()
                            .AddTransient<SignupPage>()
                            .AddTransient<SigninPage>();
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
                .ConfigureHttpClient(httpClient =>
                {
                    var baseUrl = DeviceInfo.Platform == DevicePlatform.Android 
                                    ? "https://10.0.2.2:7274"
                                    : "https://localhost:7274";
                    httpClient.BaseAddress = new Uri(baseUrl);
                });
        }
    }
}
