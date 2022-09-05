namespace ChickAndPaddy;

public class SettingsPageViewModel : NavigationAwareBaseViewModel
{
    public SettingsPageViewModel(
        IAppNavigator appNavigator)
        : base(appNavigator)
    {
    }

    ICommand _EditProfileCommand;
    public ICommand EditProfileCommand => _EditProfileCommand ??= new Command(ExecuteEditProfileCommand);
    private void ExecuteEditProfileCommand()
    {

    }

    ICommand _ChangePasswordCommand;
    public ICommand ChangePasswordCommand => _ChangePasswordCommand ??= new Command(ExecuteChangePasswordCommand);
    private void ExecuteChangePasswordCommand()
    {

    }
}

