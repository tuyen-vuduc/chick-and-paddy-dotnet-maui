namespace ChickAndPaddy;

public partial class SignUpPage
{
	public SignUpPage(SignUpPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}

