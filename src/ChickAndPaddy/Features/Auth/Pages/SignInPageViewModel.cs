namespace ChickAndPaddy;

public partial class SignInPageViewModel(
        IAppSettingsService appSettingsService,
        IAppNavigator appNavigator) : BaseViewModel(appNavigator)
{
    private readonly IAppSettingsService appSettingsService = appSettingsService;

    public SignInFormModel Form { get; init; } = new();

    [RelayCommand]
    Task SignInAsync()
    {
        var isValid = Form.IsValid();

        if (!isValid)
        {
            return Task.CompletedTask;
        }

        appSettingsService.SetAccessTokenAsync(
            Convert.ToBase64String(
                System.Text.Encoding.UTF8.GetBytes(
                    $"{Form.UserName}:{Form.Password}"
                )
            )
        );

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

