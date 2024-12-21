using InleverenWeek4MobileDev;
using InleverenWeek4MobileDev.Models;
using InleverenWeek4MobileDev.Models.DTO;
using InleverenWeek4MobileDev.Repositories;
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
            builder.Services.AddSingleton<Models.DTO.MemberAssignment>();
            builder.Services.AddSingleton<MemberChallenge>();
            builder.Services.AddSingleton<UserSessionRepository>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
