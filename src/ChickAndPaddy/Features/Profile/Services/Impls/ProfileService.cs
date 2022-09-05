namespace ChickAndPaddy;

public class ProfileService : IProfileService
{
    private readonly IPreferences preferences;

    public ProfileService(
        IPreferences preferences
        )
	{
        this.preferences = preferences;
    }

    public string MyPairingId => "123789";

    public Task<bool> CheckRelationshipAsync()
    {
        return Task.Run(() => preferences.Get<bool>(nameof(CheckRelationshipAsync), false));
    }

    public Task SetRelationshipAsync(bool paired)
    {
        return Task.Run(() => preferences.Set<bool>(nameof(CheckRelationshipAsync), paired));
    }
}

