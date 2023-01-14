namespace ChickAndPaddy;

public class AppSettingsService : IAppSettingsService
{
    private readonly IPreferences preferences;
    private readonly ISecureStorage secureStorage;

    public AppSettingsService(
        IPreferences preferences,
        ISecureStorage secureStorage
        )
    {
        this.preferences = preferences;
        this.secureStorage = secureStorage;
    }

    public string MyPairingId
    {
        get => preferences.Get<string>(nameof(MyPairingId), "123789", nameof(ChickAndPaddy));
        set => preferences.Set<string>(nameof(MyPairingId), value, nameof(ChickAndPaddy));
    }

    public bool IsFirstTime
    {
        get => preferences.Get<bool>(nameof(IsFirstTime), true, nameof(ChickAndPaddy));
        set => preferences.Set<bool>(nameof(IsFirstTime), value, nameof(ChickAndPaddy));
    }

    public async Task SetAccessTokenAsync(string value)
    {
        if (DeviceInfo.Platform == DevicePlatform.iOS)
        {
            // TODO Uncomment for real app with Apple Developer Account
            // await secureStorage.SetAsync(nameof(SetAccessTokenAsync), value);
            preferences.Set<string>(nameof(SetAccessTokenAsync), value, nameof(ChickAndPaddy));
            return;
        }

        await secureStorage.SetAsync(nameof(SetAccessTokenAsync), value);
    }
    public async Task<string> GetAccessTokenAsync()
    {
        if (DeviceInfo.Platform == DevicePlatform.iOS)
        {
            // TODO Uncomment for real app with Apple Developer Account
            // return await secureStorage.GetAsync(nameof(SetAccessTokenAsync));

            return preferences.Get<string>(nameof(SetAccessTokenAsync), null, nameof(ChickAndPaddy));
        }

        return await secureStorage.GetAsync(nameof(SetAccessTokenAsync));
    }

    public bool InARelationship
    {
        get => preferences.Get<bool>(nameof(InARelationship), false, nameof(ChickAndPaddy));
        set => preferences.Set<bool>(nameof(InARelationship), value, nameof(ChickAndPaddy));
    }

    public void Clear()
    {
        preferences.Clear();
        secureStorage.RemoveAll();
        IsFirstTime = false;
    }
}

