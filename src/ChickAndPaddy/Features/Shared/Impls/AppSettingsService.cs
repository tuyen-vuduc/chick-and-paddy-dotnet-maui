namespace ChickAndPaddy;

public class AppSettingsService : IAppSettingsService
{
    private readonly IPreferences preferences;

    public AppSettingsService(
        IPreferences preferences
        )
    {
        this.preferences = preferences;
    }

    public string MyPairingId {
        get => preferences.Get<string>(nameof(MyPairingId), "123789", nameof(ChickAndPaddy));
        set => preferences.Set<string>(nameof(MyPairingId), value, nameof(ChickAndPaddy));
    }
}

