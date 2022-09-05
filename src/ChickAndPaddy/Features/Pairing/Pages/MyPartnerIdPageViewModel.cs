namespace ChickAndPaddy;

public class MyPartnerIdPageViewModel : NavigationAwareBaseViewModel
{
    private readonly IPairingService pairingService;

    public MyPartnerIdPageViewModel(
        IPairingService pairingService,
        IAppNavigator appNavigator)
        : base(appNavigator)
    {
        this.pairingService = pairingService;
    }

    public string PartnerId { get; set; }
    public bool IdNotFound { get; set; } = false;

    ICommand _FindPartnerCommand;
    public ICommand FindPartnerCommand => _FindPartnerCommand ??= new Command(ExecuteFindPartnerCommand);
    private async void ExecuteFindPartnerCommand()
    {
        var partner = await pairingService.FindPartnerByPairingIdAsync(PartnerId);      

        IdNotFound = partner == null;

        if (IdNotFound) return;

        AppNavigator
            .NavigateAsync(AppRoutes.PartnerFound, args: partner)
            .FireAndForget();
    }
}

