namespace ChickAndPaddy;

public partial class SignUpPageViewModel : NavigationAwareBaseViewModel
{
    public SignUpPageViewModel(
        IAppNavigator appNavigator)
        : base(appNavigator)
    {
        Form = new();
    }

    public SignUpFormModel Form { get; init; }

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

