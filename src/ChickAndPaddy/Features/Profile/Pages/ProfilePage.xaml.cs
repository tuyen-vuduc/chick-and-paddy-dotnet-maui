namespace ChickAndPaddy;

public partial class ProfilePage
{
	public ProfilePage(ProfilePageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}

