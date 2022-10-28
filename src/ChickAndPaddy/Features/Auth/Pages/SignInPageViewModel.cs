namespace ChickAndPaddy;

public partial class SignInPageViewModel : BaseViewModel
{
    public SignInPageViewModel(
        IAppNavigator appNavigator)
        : base(appNavigator)
    {
        Form = new();
    }

    public SignInFormModel Form { get; init; }

    [RelayCommand]
    Task SignInAsync()
    {
        var isValid = Form.IsValid();

        if (!isValid)
        {
            return Task.CompletedTask;
        }

        return GoHomeAsync();
    }

    [RelayCommand]
    Task SignUpAsync() => AppNavigator.NavigateAsync(AppRoutes.SignUp);

    [RelayCommand]
    Task ForgotPasswordAsync() => AppNavigator.NavigateAsync(AppRoutes.ForgotPassword);

    [RelayCommand]
    Task SignInWithSocialAccountAsync(SocialAccountType socialAccountType)
    {
        return GoHomeAsync();
    }

    Task GoHomeAsync() => AppNavigator.NavigateAsync(AppRoutes.Home);
}

