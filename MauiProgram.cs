using BRMobile;
using BRMobile.Repository;
using BRMobile.Services;
using BRMobile.ViewModels;
using BRMobile.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace ManagerJR.BRMobile
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
                });

            builder.Services.AddSingleton<IHttpsClientHandlerService, HttpsClientHandlerService>();
            builder.Services.AddSingleton<IRepository, Repository>();
            builder.Services.AddTransient<TiendasPage>();
            builder.Services.AddTransient<TiendasViewModel>();
            builder.Services.AddTransient<EncuestasPage>();
            builder.Services.AddTransient<EncuestasViewModel>();
            builder.Services.AddTransient<EncuestasDetallePage>();
            builder.Services.AddTransient<EncuestasDetalleViewModel>();
            builder.Services.AddTransient<EncuestaPage>();
            builder.Services.AddTransient<EncuestaFormViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}