namespace ChickAndPaddy;

public partial class PairPageViewModel : NavigationAwareBaseViewModel
{
    public PairPageViewModel(
        IAppNavigator appNavigator)
        : base(appNavigator)
    {
    }

    [RelayCommand]
    private Task ViewMyPairingIdAsync() => AppNavigator.NavigateAsync(AppRoutes.MyPairingId);

    [RelayCommand]
    private Task EnterMyPartnerIdAsync() => AppNavigator.NavigateAsync(AppRoutes.MyPartnerId);
}

