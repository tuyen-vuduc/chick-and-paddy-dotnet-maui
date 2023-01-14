namespace ChickAndPaddy;

public class ProfileService : IProfileService
{
    private readonly IAppSettingsService appSettings;

    public ProfileService(
        IAppSettingsService appSettings
        )
	{
        this.appSettings = appSettings;
    }

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

