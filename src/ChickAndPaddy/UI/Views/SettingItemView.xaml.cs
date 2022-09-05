namespace ChickAndPaddy;

public partial class SettingItemView : ContentView
{
	public SettingItemView()
	{
		InitializeComponent();
	}

	public static readonly BindableProperty IconSourceProperty = BindableProperty.Create(
		nameof(IconSource),
		typeof(ImageSource),
		typeof(SettingItemView),
		default,
        BindingMode.OneWay
	);
    public ImageSource IconSource
	{
		get => (ImageSource)GetValue(IconSourceProperty);
		set => SetValue(IconSourceProperty, value);
    }

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(
        nameof(Title),
        typeof(string),
        typeof(SettingItemView),
        default,
        BindingMode.OneWay
    );
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public static readonly BindableProperty ShowRightAngleProperty = BindableProperty.Create(
        nameof(ShowRightAngle),
        typeof(bool),
        typeof(SettingItemView),
        true,
        BindingMode.OneWay
    );
    public bool ShowRightAngle
    {
        get => (bool)GetValue(ShowRightAngleProperty);
        set => SetValue(ShowRightAngleProperty, value);
    }
}
