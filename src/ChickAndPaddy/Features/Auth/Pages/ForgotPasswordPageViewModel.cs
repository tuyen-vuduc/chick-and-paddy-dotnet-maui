namespace ChickAndPaddy;

public partial class ForgotPasswordPageViewModel : NavigationAwareBaseViewModel
{
    public ForgotPasswordPageViewModel(
        IAppNavigator appNavigator)
        : base(appNavigator)
    {
        Form = new();
    }

    [ObservableProperty]
    ForgotPasswordFormModel form;

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

