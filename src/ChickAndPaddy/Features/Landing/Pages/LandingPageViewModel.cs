namespace ChickAndPaddy;

public class LandingPageViewModel : BaseViewModel
{
    private readonly IAppSettingsService appSettingsService;
    private readonly IAppInfo appInfo;

    public LandingPageViewModel(
        IAppSettingsService appSettingsService,
        IAppNavigator appNavigator,
        IAppInfo appInfo)
        : base(appNavigator)
    {
        this.appSettingsService = appSettingsService;
        this.appInfo = appInfo;
    }

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

