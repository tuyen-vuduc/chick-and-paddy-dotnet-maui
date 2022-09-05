namespace ChickAndPaddy;

public partial class MyWallHeaderView : ContentView
{
    public MyWallHeaderView()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty AddCommandProperty = BindableProperty.Create(
        nameof(AddCommand),
        typeof(ICommand),
        typeof(CoupleHeaderView),
        default,
        BindingMode.OneWay
    );
    public ICommand AddCommand
    {
        get => (ICommand)GetValue(AddCommandProperty);
        set => SetValue(AddCommandProperty, value);
    }

    public static readonly BindableProperty ModeCommandProperty = BindableProperty.Create(
        nameof(ModeCommand),
        typeof(ICommand),
        typeof(CoupleHeaderView),
        default,
        BindingMode.OneWay
    );
    public ICommand ModeCommand
    {
        get => (ICommand)GetValue(ModeCommandProperty);
        set => SetValue(ModeCommandProperty, value);
    }

    public object ModeCommandParameter { get; set; }

    public static readonly BindableProperty ViewMilestonesCommandProperty = BindableProperty.Create(
        nameof(ViewMilestonesCommand),
        typeof(ICommand),
        typeof(CoupleHeaderView),
        default,
        BindingMode.OneWay
    );
    public ICommand ViewMilestonesCommand
    {
        get => (ICommand)GetValue(ViewMilestonesCommandProperty);
        set => SetValue(ViewMilestonesCommandProperty, value);
    }

    public static readonly BindableProperty ViewObjectivesCommandProperty = BindableProperty.Create(
        nameof(ViewObjectivesCommand),
        typeof(ICommand),
        typeof(CoupleHeaderView),
        default,
        BindingMode.OneWay
    );
    public ICommand ViewObjectivesCommand
    {
        get => (ICommand)GetValue(ViewObjectivesCommandProperty);
        set => SetValue(ViewObjectivesCommandProperty, value);
    }
}
