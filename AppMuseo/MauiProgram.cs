using AppMuseo.Logic;
using AppMuseo.Logic.Services;
using AppMuseo.Views;
using Microsoft.Extensions.Logging;

namespace AppMuseo
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

#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<ISchedaOperaDataProvider, SchedaOperaDataProvider>();

            builder.Services.AddSingleton<ILLamaCpp, LLamaCpp>();

            builder.Services.AddTransient<AudioGuida>();

            return builder.Build();
        }
    }
}


