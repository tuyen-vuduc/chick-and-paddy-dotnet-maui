namespace ChickAndPaddy;

public partial class NotificationsPage
{
	public NotificationsPage(NotificationsPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}
