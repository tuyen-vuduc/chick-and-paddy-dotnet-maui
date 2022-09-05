namespace ChickAndPaddy;

public partial class MyPartnerIdPage
{
	public MyPartnerIdPage(MyPartnerIdPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}

