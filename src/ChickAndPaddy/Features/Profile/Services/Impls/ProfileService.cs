namespace ChickAndPaddy;

public class ProfileService(
        IAppSettingsService appSettings
        ) : IProfileService
{
    private readonly IAppSettingsService appSettings = appSettings;

    public string MyPairingId => "123789";

    public Task<bool> CheckRelationshipAsync()
    {
        return Task.FromResult(appSettings.InARelationship);
    }

    public Task SetRelationshipAsync(bool paired)
    {
        return Task.Run(() => appSettings.InARelationship = paired);
    }
}

