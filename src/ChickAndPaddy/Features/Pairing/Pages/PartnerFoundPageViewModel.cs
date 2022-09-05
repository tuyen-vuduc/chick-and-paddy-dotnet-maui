namespace ChickAndPaddy;

public class PartnerFoundPageViewModel : NavigationAwareBaseViewModel
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

        messagingCenter.Subscribe<object, bool>(this, AppMessages.PAIRING_RESPONSE, HandlePairingResponse);
    }

    public PartnerModel Partner { get; set; }
    public DateTime FirstMet { get; set; } = DateTime.Today;

    public int DaysSinceMet { get => (DateTime.Today - FirstMet.Date).Days + 1; }

    public void OnFirstMetChanged()
    {
        if (Partner == null) return;

        Partner.FirstMet = FirstMet;
    }

    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        Partner = query.GetData<PartnerModel>();
    }

    ICommand _SendRequestCommand;
    public ICommand SendRequestCommand => _SendRequestCommand ??= new Command(ExecuteSendRequestCommand);
    private void ExecuteSendRequestCommand()
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

