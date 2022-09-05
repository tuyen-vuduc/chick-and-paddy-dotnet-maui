namespace ChickAndPaddy;

public class MyPairingIdPageViewModel : NavigationAwareBaseViewModel
{
    private readonly IPairingService pairingService;

    public MyPairingIdPageViewModel(
        IPairingService pairingService,
        IAppNavigator appNavigator)
        : base(appNavigator)
    {
        this.pairingService = pairingService;
    }

    public string MyPairingId { get; set; }
    public string SharedLink { get => $"cap://connect/{MyPairingId}"; }

    protected override async void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        MyPairingId = await pairingService.GetMyPairingIdAsync();
    }

    ICommand _ShareLinkCommand;
    public ICommand ShareLinkCommand => _ShareLinkCommand ??= new Command(ExecuteShareLinkCommand);
    private void ExecuteShareLinkCommand() => AppNavigator.ShareAsync(SharedLink, "ID ghép đôi");
}

