namespace ChickAndPaddy;

public class PairPageViewModel : NavigationAwareBaseViewModel
{
    public PairPageViewModel(
        IAppNavigator appNavigator)
        : base(appNavigator)
    {
    }

    ICommand _MyPairingIdCommand;
    public ICommand MyPairingIdCommand => _MyPairingIdCommand ??= new Command(ExecuteMyPairingIdCommand);
    private void ExecuteMyPairingIdCommand() => AppNavigator.NavigateAsync(AppRoutes.MyPairingId);

    ICommand _MyPartnerIdCommand;
    public ICommand MyPartnerIdCommand => _MyPartnerIdCommand ??= new Command(ExecuteMyPartnerIdCommand);
    private void ExecuteMyPartnerIdCommand() => AppNavigator.NavigateAsync(AppRoutes.MyPartnerId);
}

