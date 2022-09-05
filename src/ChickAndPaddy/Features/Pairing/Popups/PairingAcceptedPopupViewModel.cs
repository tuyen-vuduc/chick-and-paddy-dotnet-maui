using System;
namespace ChickAndPaddy
{
    public class PairingAcceptedPopupViewModel : BaseViewModel
    {
        public PairingAcceptedPopupViewModel(
            IAppNavigator appNavigator
            ) : base(appNavigator)
        {
        }

        ICommand _DoneCommand;
        public ICommand DoneCommand { get => _DoneCommand ??= new Command(ExecuteDoneCommand); }
        private void ExecuteDoneCommand(object obj) => AppNavigator.NavigateAsync(AppRoutes.Home);
    }
}