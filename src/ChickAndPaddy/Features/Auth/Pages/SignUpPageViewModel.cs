namespace ChickAndPaddy;

public class SignUpPageViewModel : NavigationAwareBaseViewModel
{
    public SignUpPageViewModel(
        IAppNavigator appNavigator)
        : base(appNavigator)
    {
    }

    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }

    ICommand _SignUpCommand;
    public ICommand SignUpCommand => _SignUpCommand ??= new Command(ExecuteSignUpCommand);
    void ExecuteSignUpCommand() => AppNavigator.GoBackAsync();
}

