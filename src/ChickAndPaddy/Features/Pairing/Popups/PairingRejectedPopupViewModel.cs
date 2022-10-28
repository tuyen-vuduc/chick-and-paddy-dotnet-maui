using System;
namespace ChickAndPaddy
{
    public partial class PairingRejectedPopupViewModel : BaseViewModel
    {
        public PairingRejectedPopupViewModel(
            IAppNavigator appNavigator
            ) : base(appNavigator)
        {
        }

        [RelayCommand]
        private Task Done(object obj) => AppNavigator.NavigateAsync(AppRoutes.Home);

        [RelayCommand]
        private Task Retry(object obj) => AppNavigator.GoBackAsync(true);
    }
}

