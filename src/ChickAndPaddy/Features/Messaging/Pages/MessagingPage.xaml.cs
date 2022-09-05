namespace ChickAndPaddy;

public partial class MessagingPage
{
	public MessagingPage(MessagingPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}

