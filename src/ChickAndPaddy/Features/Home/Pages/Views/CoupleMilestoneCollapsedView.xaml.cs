namespace ChickAndPaddy;

public partial class CoupleMilestoneCollapsedView : ContentView
{
    public CoupleMilestoneCollapsedView()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty MoreCommandProperty = BindableProperty.Create(
        nameof(MoreCommand),
        typeof(ICommand),
        typeof(CoupleMilestoneCollapsedView),
        default,
        BindingMode.OneWay
    );
    public ICommand MoreCommand
    {
        get => (ICommand)GetValue(MoreCommandProperty);
        set => SetValue(MoreCommandProperty, value);
    }
}
