namespace ChickAndPaddy;

public partial class ProfilePageViewModel(IAppNavigator appNavigator) : NavigationAwareBaseViewModel(appNavigator)
{

    [ObservableProperty]
    string phoneNumber;

    [RelayCommand]
    private Task ViewSettings() => AppNavigator.NavigateAsync(AppRoutes.SettingsAndHelp);
}