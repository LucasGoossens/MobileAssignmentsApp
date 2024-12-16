using InleverenWeek4MobileDev;
using InleverenWeek4MobileDev.Models;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace InleverenWeek4MobileDev
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

            builder.Services.AddSingleton<User>();
            builder.Services.AddSingleton<Challenge>();
            builder.Services.AddSingleton<Assignment>();
            builder.Services.AddSingleton<MemberAssignment>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
