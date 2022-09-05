namespace ChickAndPaddy;

public partial class PairingAcceptedPopup
{
	public PairingAcceptedPopup(PairingAcceptedPopupViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}
