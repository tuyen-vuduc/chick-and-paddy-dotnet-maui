namespace ChickAndPaddy;

public partial class PartnerFoundPageViewModel : NavigationAwareBaseViewModel
{
    private readonly IProfileService profileService;
    private readonly IPairingService pairingService;
    private readonly IMessagingCenter messagingCenter;

    public PartnerFoundPageViewModel(
        IProfileService profileService,
        IPairingService pairingService,
        IMessagingCenter messagingCenter,
        IAppNavigator appNavigator)
        : base(appNavigator)
    {
        this.profileService = profileService;
        this.pairingService = pairingService;
        this.messagingCenter = messagingCenter;

        messagingCenter.Unsubscribe<object, bool>(this, AppMessages.PAIRING_RESPONSE);
        messagingCenter.Subscribe<object, bool>(this, AppMessages.PAIRING_RESPONSE, HandlePairingResponse);
    }

    [ObservableProperty]
    PartnerModel partner;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(DaysSinceMet))]
    DateTime firstMet = DateTime.Today;

    public int DaysSinceMet { get => (DateTime.Today - FirstMet.Date).Days + 1; }

    partial void OnFirstMetChanged(DateTime value)
    {
        if (Partner == null) return;

        Partner.FirstMet = value;
    }

    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        Partner = query.GetData<PartnerModel>();
    }

    protected override Task BackAsync()
    {
        messagingCenter.Unsubscribe<object, bool>(this, AppMessages.PAIRING_RESPONSE);

        return base.BackAsync();
    }

    [RelayCommand]
    private void SendRequest()
    {
        pairingService
            .SendPairingRequestAsync(Partner)
            .FireAndForget();

        AppNavigator
            .ShowSnackbarAsync("Bạn đã gửi lời mời ghép đôi thành công, hãy đợi đối tác phản hồi nhé.")
            .FireAndForget();
    }

    private void HandlePairingResponse(object sender, bool accepted)
    {
        if (!accepted)
        {
            AppNavigator.NavigateAsync(AppRoutes.PairingRejected);

            return;
        }

        profileService.SetRelationshipAsync(accepted);
        AppNavigator.NavigateAsync(AppRoutes.PairingAccepted);
    }
}

