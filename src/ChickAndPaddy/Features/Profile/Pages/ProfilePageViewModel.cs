namespace ChickAndPaddy;

public class ProfilePageViewModel : NavigationAwareBaseViewModel
{
    public ProfilePageViewModel(
        IAppNavigator appNavigator)
        : base(appNavigator)
    {
    }

    public string PhoneNumber { get; set; }

    ICommand _ViewSettingsCommand;
    public ICommand ViewSettingsCommand => _ViewSettingsCommand ??= new Command(ExecuteViewSettingsCommand);
    private void ExecuteViewSettingsCommand()
    {
        AppNavigator.NavigateAsync(AppRoutes.SettingsAndHelp);
    }
}