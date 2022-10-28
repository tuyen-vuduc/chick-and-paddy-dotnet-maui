namespace ChickAndPaddy;

public partial class MessagingPageViewModel : NavigationAwareBaseViewModel
{
    public MessagingPageViewModel(
        IAppNavigator appNavigator)
        : base(appNavigator)
    {
    }

    [ObservableProperty]
    string phoneNumber;

    [RelayCommand]
    private void GetOTP()
    {

    }
}

