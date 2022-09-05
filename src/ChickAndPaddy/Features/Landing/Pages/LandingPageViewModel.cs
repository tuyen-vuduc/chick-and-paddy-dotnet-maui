namespace ChickAndPaddy;

public class LandingPageViewModel : BaseViewModel
{
    private readonly IAppInfo appInfo;

    public LandingPageViewModel(
        IAppNavigator appNavigator,
        IAppInfo appInfo)
        : base(appNavigator)
    {
        this.appInfo = appInfo;
    }

    public string VersionInfo => $"{appInfo.VersionString} ({appInfo.BuildString})";

    public override async Task OnAppearingAsync()
    {
        await Task.Delay(500);

        await AppNavigator.NavigateAsync(AppRoutes.Walkthrough);
    }
}

