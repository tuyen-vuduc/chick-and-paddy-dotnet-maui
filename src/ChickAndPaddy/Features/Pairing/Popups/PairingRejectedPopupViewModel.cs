namespace ChickAndPaddy
{
    public partial class PairingRejectedPopupViewModel(IAppNavigator appNavigator) : BaseViewModel(appNavigator)
    {

        [RelayCommand]
        private Task Done(object obj) => AppNavigator.NavigateAsync(AppRoutes.Home);

        [RelayCommand]
        private Task Retry(object obj) => AppNavigator.GoBackAsync(true);
    }
}

