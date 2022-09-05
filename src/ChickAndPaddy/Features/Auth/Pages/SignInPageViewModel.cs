namespace ChickAndPaddy;

public class SignInPageViewModel : BaseViewModel
{
    public SignInPageViewModel(
        IAppNavigator appNavigator)
        : base(appNavigator)
    {
    }

    public string UserName { get; set; }
    public string Password { get; set; }

    ICommand _SignInCommand;
    public ICommand SignInCommand => _SignInCommand ??= new Command(ExecuteSignInCommand);
    void ExecuteSignInCommand() {
        GoHomeAsync();
    }

    ICommand _SignUpCommand;
    public ICommand SignUpCommand => _SignUpCommand ??= new Command(ExecuteSignUpCommand);
    void ExecuteSignUpCommand() => AppNavigator.NavigateAsync(AppRoutes.SignUp);

    ICommand _ForgotPasswordCommand;
    public ICommand ForgotPasswordCommand => _ForgotPasswordCommand ??= new Command(ExecuteForgotPasswordCommand);
    void ExecuteForgotPasswordCommand() => AppNavigator.NavigateAsync(AppRoutes.ForgotPassword);

    ICommand _SignInWithSocialAccountCommand;
    public ICommand SignInWithSocialAccountCommand => _SignInWithSocialAccountCommand ??= new Command<SocialAccountType>(ExecuteSignInWithSocialAccountCommand);
    void ExecuteSignInWithSocialAccountCommand(SocialAccountType socialAccountType) {
        GoHomeAsync();
    }

    Task GoHomeAsync() => AppNavigator.NavigateAsync(AppRoutes.Home);
}

