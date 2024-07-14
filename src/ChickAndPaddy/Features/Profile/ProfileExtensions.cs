namespace ChickAndPaddy;
public static class ProfileExtensions
{
    public static MauiAppBuilder RegisterProfile(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<INotificationService, NotificationService>();
        builder.Services.AddSingleton<IProfileService, ProfileService>();
        return builder;
    }
}
