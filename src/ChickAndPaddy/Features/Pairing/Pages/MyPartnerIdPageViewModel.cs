namespace ChickAndPaddy;

public partial class MyPartnerIdPageViewModel(
        IPairingService pairingService,
        IAppNavigator appNavigator) : NavigationAwareBaseViewModel(appNavigator)
{
    private readonly IPairingService pairingService = pairingService;

    [ObservableProperty]
    string partnerId;

    [ObservableProperty]
    bool idNotFound;

    [RelayCommand]
    private async Task FindPartnerAsync()
    {
        var partner = await pairingService.FindPartnerByPairingIdAsync(PartnerId);

        IdNotFound = partner == null;

        if (IdNotFound) return;

        AppNavigator
            .NavigateAsync(AppRoutes.PartnerFound, args: partner)
            .FireAndForget();
    }
}

