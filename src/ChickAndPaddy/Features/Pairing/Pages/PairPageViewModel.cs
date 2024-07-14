namespace ChickAndPaddy;

public partial class PairPageViewModel(IAppNavigator appNavigator) : NavigationAwareBaseViewModel(appNavigator)
{

    [RelayCommand]
    private Task ViewMyPairingIdAsync() => AppNavigator.NavigateAsync(AppRoutes.MyPairingId);

    [RelayCommand]
    private Task EnterMyPartnerIdAsync() => AppNavigator.NavigateAsync(AppRoutes.MyPartnerId);
}

