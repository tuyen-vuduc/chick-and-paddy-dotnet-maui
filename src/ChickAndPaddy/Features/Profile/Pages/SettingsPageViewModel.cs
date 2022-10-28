namespace ChickAndPaddy;

public partial class SettingsPageViewModel : NavigationAwareBaseViewModel
{
    public SettingsPageViewModel(
        IAppNavigator appNavigator)
        : base(appNavigator)
    {
    }

    [RelayCommand]
    private void EditProfile()
    {

    }

    [RelayCommand]
    private void ChangePassword()
    {

    }
}

