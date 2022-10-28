namespace ChickAndPaddy;

public partial class GamesPageViewModel : NavigationAwareBaseViewModel
{
    public GamesPageViewModel(
        IAppNavigator appNavigator)
        : base(appNavigator)
    {
    }

    string phoneNumber;

    [RelayCommand]
    private void ExecuteGetOTPCommand()
    {

    }
}

