namespace ChickAndPaddy;

public partial class PairingRejectedPopup
{
	public PairingRejectedPopup(PairingRejectedPopupViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}
