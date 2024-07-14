namespace ChickAndPaddy;

public partial class ForgotPasswordPageViewModel(
        IAppNavigator appNavigator) : NavigationAwareBaseViewModel(appNavigator)
{

    [ObservableProperty]
    ForgotPasswordFormModel form = new();

    [RelayCommand]
    private void GetOTP()
    {
        var isValid = Form.IsValid();

        if (!isValid)
        {
            // Do something
        }
    }
}

