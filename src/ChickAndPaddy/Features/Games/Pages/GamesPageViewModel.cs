namespace ChickAndPaddy;

public class GamesPageViewModel : NavigationAwareBaseViewModel
{
    public GamesPageViewModel(
        IAppNavigator appNavigator)
        : base(appNavigator)
    {
    }

    public string PhoneNumber { get; set; }

    ICommand _GetOTPCommand;
    public ICommand GetOTPCommand => _GetOTPCommand ??= new Command(ExecuteGetOTPCommand);
    private void ExecuteGetOTPCommand()
    {

    }
}

