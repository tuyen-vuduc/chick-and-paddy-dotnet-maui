using System;
namespace ChickAndPaddy
{
    public class PairingRejectedPopupViewModel : BaseViewModel
    {
        public PairingRejectedPopupViewModel(
            IAppNavigator appNavigator
            ) : base(appNavigator)
        {
        }

        ICommand _DoneCommand;
        public ICommand DoneCommand { get => _DoneCommand ??= new Command(ExecuteDoneCommand); }
        private void ExecuteDoneCommand(object obj) => AppNavigator.NavigateAsync(AppRoutes.Home);

        ICommand _RetryCommand;
        public ICommand RetryCommand { get => _RetryCommand ??= new Command(ExecuteRetryCommand); }
        private void ExecuteRetryCommand(object obj) => AppNavigator.GoBackAsync(true);
    }
}

