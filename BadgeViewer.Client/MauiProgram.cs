using BadgeViewer.Core.Services;
using BadgeViewer.Dal.Repository;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using BadgeViewer.Client.ViewModels;

namespace BadgeViewer.Client
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            }).UseMauiCommunityToolkit();
#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<IUserManagerService, UserManagerService>();
            builder.Services.AddSingleton<IBadgeDataRepository, BadgeDataRepository>();
            builder.Services.AddSingleton<MainPageViewModel>();

            return builder.Build();
        }
    }
}