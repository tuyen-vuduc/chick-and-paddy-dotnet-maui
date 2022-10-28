using System;
namespace ChickAndPaddy
{
    public partial class PairingAcceptedPopupViewModel : BaseViewModel
    {
        public PairingAcceptedPopupViewModel(
            IAppNavigator appNavigator
            ) : base(appNavigator)
        {
        }

        [RelayCommand]
        private Task Done(object obj) => AppNavigator.NavigateAsync(AppRoutes.Home);
    }
}