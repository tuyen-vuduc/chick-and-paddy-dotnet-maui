namespace ChickAndPaddy;

public partial class SettingsAndHelpPageViewModel : NavigationAwareBaseViewModel
{
    private readonly IPreferences preferences;

    public SettingsAndHelpPageViewModel(
        IPreferences preferences,
        IAppNavigator appNavigator)
        : base(appNavigator)
    {
        this.preferences = preferences;
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
        preferences.Clear();
        return AppNavigator.NavigateAsync(AppRoutes.SignIn);
    }
}

