namespace ChickAndPaddy;

public interface IAppSettingsService
{
    Task SetAccessTokenAsync(string value);
    Task<string> GetAccessTokenAsync();

    string MyPairingId { get; set; }

    bool InARelationship { get; set; }

    bool IsFirstTime { get; set; }

    void Clear();
}

