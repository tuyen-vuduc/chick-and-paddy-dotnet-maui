namespace ChickAndPaddy;

public class SettingsAndHelpPageViewModel : NavigationAwareBaseViewModel
{
    private readonly IPreferences preferences;

    public SettingsAndHelpPageViewModel(
        IPreferences preferences,
        IAppNavigator appNavigator)
        : base(appNavigator)
    {
        this.preferences = preferences;
    }

    ICommand _CancelRelationshipCommand;
    public ICommand CancelRelationshipCommand => _CancelRelationshipCommand ??= new Command(ExecuteCancelRelationshipCommand);
    private void ExecuteCancelRelationshipCommand()
    {

    }

    ICommand _ViewSettingsCommand;
    public ICommand ViewSettingsCommand => _ViewSettingsCommand ??= new Command(ExecuteViewSettingsCommand);
    private void ExecuteViewSettingsCommand()
    {
        AppNavigator.NavigateAsync(AppRoutes.Settings);
    }

    ICommand _ViewNotificationsCommand;
    public ICommand ViewNotificationsCommand => _ViewNotificationsCommand ??= new Command(ExecuteViewNotificationsCommand);
    private void ExecuteViewNotificationsCommand()
    {
        AppNavigator.NavigateAsync(AppRoutes.Notifications);
    }

    ICommand _SupportCommand;
    public ICommand SupportCommand => _SupportCommand ??= new Command(ExecuteSupportCommand);
    private void ExecuteSupportCommand()
    {

    }

    ICommand _SignOutCommand;
    public ICommand SignOutCommand => _SignOutCommand ??= new Command(ExecuteSignOutCommand);
    private void ExecuteSignOutCommand()
    {
        preferences.Clear();
        AppNavigator.NavigateAsync(AppRoutes.SignIn);
    }
}

