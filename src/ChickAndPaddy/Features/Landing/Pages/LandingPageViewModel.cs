namespace ChickAndPaddy;

public class LandingPageViewModel(
        IAppSettingsService appSettingsService,
        IAppNavigator appNavigator,
        IAppInfo appInfo) : BaseViewModel(appNavigator)
{
    private readonly IAppSettingsService appSettingsService = appSettingsService;
    private readonly IAppInfo appInfo = appInfo;

    public string VersionInfo => $"{appInfo.VersionString} ({appInfo.BuildString})";

    public override async Task OnAppearingAsync()
    {
        await Task.Delay(500);

        var accessToken = await appSettingsService.GetAccessTokenAsync();
        var route = string.IsNullOrWhiteSpace(accessToken)
            ? appSettingsService.IsFirstTime
            ? AppRoutes.Walkthrough
            : AppRoutes.SignIn
            : AppRoutes.Home;

        appSettingsService.IsFirstTime = false;
        await AppNavigator.NavigateAsync(route);
    }
}

