namespace ChickAndPaddy;

public class PairingService(
        IAppSettingsService appSettingsService,
        IMessagingCenter messagingCenter
    ) : IPairingService
{
    private readonly IAppSettingsService appSettingsService = appSettingsService;
    private readonly IMessagingCenter messagingCenter = messagingCenter;

    public Task<PartnerModel> FindPartnerByPairingIdAsync(string pairingId)
    {
        if (pairingId?.Contains('0') == true) return Task.FromResult<PartnerModel>(null);

        var partner = new PartnerModel
        {
            Id = Guid.NewGuid(),
            PairingId = pairingId,
            NickName = "Gà con",

            FirstName = "Elon",
            LastName = "Musk",

            FirstMet = DateTime.Today,
        };

        return Task.FromResult(partner);
    }

    public Task<string> GetMyPairingIdAsync()
    {
        return Task.FromResult(appSettingsService.MyPairingId);
    }

    public Task SendPairingRequestAsync(PartnerModel partner)
    {
        var accepted = !partner.PairingId.Contains('7');

        Task.Delay(750)
            .ContinueWith(t =>
            {
                messagingCenter.Send<object, bool>(this, AppMessages.PAIRING_RESPONSE, accepted);
            })
            .ConfigureAwait(false);

        return Task.CompletedTask;
    }
}

