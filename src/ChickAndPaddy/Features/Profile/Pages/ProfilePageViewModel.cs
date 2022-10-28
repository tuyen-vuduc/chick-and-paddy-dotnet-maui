namespace ChickAndPaddy;

public partial class ProfilePageViewModel : NavigationAwareBaseViewModel
{
    public ProfilePageViewModel(
        IAppNavigator appNavigator)
        : base(appNavigator)
    {
    }

    [ObservableProperty]
    string phoneNumber;

    [RelayCommand]
    private Task ViewSettings() => AppNavigator.NavigateAsync(AppRoutes.SettingsAndHelp);
}