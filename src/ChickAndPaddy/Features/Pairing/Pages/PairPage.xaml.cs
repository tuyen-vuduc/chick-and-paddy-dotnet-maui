namespace ChickAndPaddy;

public partial class PairPage
{
	public PairPage(PairPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}

