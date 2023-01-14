namespace ChickAndPaddy;

public partial class SettingsAndHelpPageViewModel : NavigationAwareBaseViewModel
{
    private readonly IAppSettingsService appSettings;

    public SettingsAndHelpPageViewModel(
        IAppSettingsService appSettings,
        IAppNavigator appNavigator)
        : base(appNavigator)
    {
        this.appSettings = appSettings;
    }

    [RelayCommand]
    private void CancelRelationship()
    {

    }

    [RelayCommand]
    private Task ViewSettingsAsync() => AppNavigator.NavigateAsync(AppRoutes.Settings);

    [RelayCommand]
    private Task ViewNotificationsAsync() => AppNavigator.NavigateAsync(AppRoutes.Notifications);

    [RelayCommand]
    private void Support()
    {

    }

    [RelayCommand]
    private Task SignOut()
    {
        appSettings.Clear();
        return AppNavigator.NavigateAsync(AppRoutes.SignIn);
    }
}

