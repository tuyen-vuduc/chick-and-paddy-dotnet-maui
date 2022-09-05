namespace ChickAndPaddy;

public partial class GamesPage
{
	public GamesPage(GamesPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}

