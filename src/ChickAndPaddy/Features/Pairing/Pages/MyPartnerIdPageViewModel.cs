namespace ChickAndPaddy;

public partial class MyPartnerIdPageViewModel : NavigationAwareBaseViewModel
{
    private readonly IPairingService pairingService;

    public MyPartnerIdPageViewModel(
        IPairingService pairingService,
        IAppNavigator appNavigator)
        : base(appNavigator)
    {
        this.pairingService = pairingService;
    }

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

