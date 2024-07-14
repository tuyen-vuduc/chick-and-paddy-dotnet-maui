namespace ChickAndPaddy;

public partial class SignUpPageViewModel(IAppNavigator appNavigator) : NavigationAwareBaseViewModel(appNavigator)
{

    public SignUpFormModel Form { get; init; } = new();

    [RelayCommand]
    Task SignUpAsync()
    {
        var isValid = Form.IsValid();

        if (!isValid)
        {
            return Task.CompletedTask;
        }

        return AppNavigator.GoBackAsync();
    }
}

