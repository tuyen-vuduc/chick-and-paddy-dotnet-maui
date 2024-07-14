namespace ChickAndPaddy;

public partial class MessagingPageViewModel(IAppNavigator appNavigator)
    : NavigationAwareBaseViewModel(appNavigator)
{

    [ObservableProperty]
    string phoneNumber;

    [RelayCommand]
    private void GetOTP()
    {

    }
}

