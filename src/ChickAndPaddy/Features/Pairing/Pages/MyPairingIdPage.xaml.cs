namespace ChickAndPaddy;

public partial class MyPairingIdPage
{
	public MyPairingIdPage(MyPairingIdPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}

