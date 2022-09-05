namespace ChickAndPaddy;

public partial class ForgotPasswordPage
{
	public ForgotPasswordPage(ForgotPasswordPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}

