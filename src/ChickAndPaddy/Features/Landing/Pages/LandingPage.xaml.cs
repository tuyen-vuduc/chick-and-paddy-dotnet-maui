namespace ChickAndPaddy;

public partial class LandingPage
{
	public LandingPage(LandingPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}

