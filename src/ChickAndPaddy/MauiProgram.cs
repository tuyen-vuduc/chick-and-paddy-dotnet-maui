using Microsoft.Maui.Platform;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Views;

namespace ChickAndPaddy;
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
                fonts.AddFont("Montserrat-Bold.ttf", FontNames.ArchiaBold);
                fonts.AddFont("Montserrat-Light.ttf", FontNames.ArchiaLight);
                fonts.AddFont("Montserrat-Medium.ttf", FontNames.ArchiaMedium);
                fonts.AddFont("Montserrat-Regular.ttf", FontNames.ArchiaRegular);
                fonts.AddFont("Montserrat-SemiBold.ttf", FontNames.ArchiaSemiBold);
                fonts.AddFont("Montserrat-Thin.ttf", FontNames.ArchiaThin);
            })
            .ConfigureEssentials(essentials =>
            {
                essentials.UseVersionTracking();
            })
            .RegisterServices()
            .RegisterPages()
            .RegisterPopups();

        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoBorderEntry", (handler, view) =>
        {
#if ANDROID
            handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
#elif IOS
            handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif WINDOWS
            handler.PlatformView.FontWeight = Microsoft.UI.Text.FontWeights.Thin;
#endif
        });

        Microsoft.Maui.Handlers.PageHandler.Mapper.AppendToMapping("Popup", (handler, view) =>
        {
#if ANDROID
            //handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
#elif IOS
            if (view is BasePopup popup)
            {
                handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
            }
#elif WINDOWS
            //handler.PlatformView.FontWeight = Microsoft.UI.Text.FontWeights.Thin;
#endif
        });
        return builder.Build();
    }

    static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<IAppInfo>(AppInfo.Current);
        builder.Services.AddSingleton<IPreferences>(Preferences.Default);
        builder.Services.AddSingleton<ISecureStorage>(SecureStorage.Default);
        builder.Services.AddSingleton<IMessagingCenter>(MessagingCenter.Instance);

        builder.Services.AddSingleton<IAppNavigator, AppNavigator>();
        builder.Services.AddSingleton<IAppSettingsService, AppSettingsService>();

        builder.Services.AddTransient<ILandingService, LandingService>();
        builder.Services.AddSingleton<INotificationService, NotificationService>();
        builder.Services.AddSingleton<IPairingService, PairingService>();
        builder.Services.AddSingleton<INewsFeedService, NewsFeedService>();
        builder.Services.AddSingleton<IProfileService, ProfileService>();

        return builder;
    }

    static MauiAppBuilder RegisterPages(this MauiAppBuilder builder)
    {
        builder.Services.AddPage<LandingPage, LandingPageViewModel>();
        builder.Services.AddPage<WalkthroughPage, WalkthroughPageViewModel>();
        builder.Services.AddPage<SignInPage, SignInPageViewModel>();
        builder.Services.AddPage<SignUpPage, SignUpPageViewModel>();
        builder.Services.AddPage<ForgotPasswordPage, ForgotPasswordPageViewModel>();
        builder.Services.AddPage<HomePage, HomePageViewModel>();
        builder.Services.AddPage<MessagingPage, MessagingPageViewModel>();
        builder.Services.AddPage<GamesPage, GamesPageViewModel>();
        builder.Services.AddPage<ProfilePage, ProfilePageViewModel>();
        builder.Services.AddPage<PairPage, PairPageViewModel>();
        builder.Services.AddPage<MyPairingIdPage, MyPairingIdPageViewModel>();
        builder.Services.AddPage<MyPartnerIdPage, MyPartnerIdPageViewModel>();
        builder.Services.AddPage<PartnerFoundPage, PartnerFoundPageViewModel>();
        builder.Services.AddPage<NotificationsPage, NotificationsPageViewModel>();
        builder.Services.AddPage<SettingsAndHelpPage, SettingsAndHelpPageViewModel>();
        builder.Services.AddPage<SettingsPage, SettingsPageViewModel>();
        return builder;
    }

    static MauiAppBuilder RegisterPopups(this MauiAppBuilder builder)
    {
        builder.Services.AddPopup<PairingAcceptedPopup, PairingAcceptedPopupViewModel>(AppRoutes.PairingAccepted);
        builder.Services.AddPopup<PairingRejectedPopup, PairingRejectedPopupViewModel>(AppRoutes.PairingRejected);

        return builder;
    }

    static IServiceCollection AddPage<TPage, TViewModel>(this IServiceCollection services)
        where TPage : BasePage where TViewModel : BaseViewModel
    {
        services.AddTransient<TPage>();
        services.AddTransient<TViewModel>();
        return services;
    }

    static IServiceCollection AddPopup<TPopup, TViewModel>(this IServiceCollection services, string name)
        where TPopup : BasePopup where TViewModel : BaseViewModel
    {
        Routing.RegisterRoute(name, typeof(TPopup));
        services.AddTransient<TPopup>();
        services.AddTransient<TViewModel>();
        return services;
    }
}