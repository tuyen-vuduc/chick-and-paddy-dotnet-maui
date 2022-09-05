namespace ChickAndPaddy;

public partial class SettingsAndHelpPage
{
	public SettingsAndHelpPage(SettingsAndHelpPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}
