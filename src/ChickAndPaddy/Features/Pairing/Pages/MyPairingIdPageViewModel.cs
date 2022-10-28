namespace ChickAndPaddy;

public partial class MyPairingIdPageViewModel : NavigationAwareBaseViewModel
{
    private readonly IPairingService pairingService;

    public MyPairingIdPageViewModel(
        IPairingService pairingService,
        IAppNavigator appNavigator)
        : base(appNavigator)
    {
        this.pairingService = pairingService;
    }

    [ObservableProperty]
    string myPairingId;

    public string SharedLink { get => $"cap://connect/{MyPairingId}"; }

    protected override async void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        MyPairingId = await pairingService.GetMyPairingIdAsync();
    }

    [RelayCommand]
    private Task ShareLinkAsync() => AppNavigator.ShareAsync(SharedLink, "ID ghép đôi");
}

