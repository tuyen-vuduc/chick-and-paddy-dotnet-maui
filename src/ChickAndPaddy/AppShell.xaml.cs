namespace ChickAndPaddy;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute("signUp", typeof(SignUpPage));
        Routing.RegisterRoute("forgotPassword", typeof(ForgotPasswordPage));
        Routing.RegisterRoute("pair", typeof(PairPage));
        Routing.RegisterRoute("myPairingId", typeof(MyPairingIdPage));
        Routing.RegisterRoute("myPartnerId", typeof(MyPartnerIdPage));
        Routing.RegisterRoute("partnerFound", typeof(PartnerFoundPage));
        Routing.RegisterRoute("notifications", typeof(NotificationsPage));
        Routing.RegisterRoute("settings-n-help", typeof(SettingsAndHelpPage));
        Routing.RegisterRoute("settings", typeof(SettingsPage));

        Routing.RegisterRoute(AppRoutes.PairingAccepted, typeof(PairingAcceptedPopup));
        Routing.RegisterRoute(AppRoutes.PairingRejected, typeof(PairingRejectedPopup));
    }

    protected override void OnNavigating(ShellNavigatingEventArgs args)
    {
        base.OnNavigating(args);
    }

    protected override void OnNavigated(ShellNavigatedEventArgs args)
    {
        base.OnNavigated(args);
    }

    protected override void OnNavigatingFrom(NavigatingFromEventArgs args)
    {
        base.OnNavigatingFrom(args);
    }

    protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        base.OnNavigatedFrom(args);
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}
