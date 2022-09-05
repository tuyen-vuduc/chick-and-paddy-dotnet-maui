namespace ChickAndPaddy;

public partial class DatePickerEntry : ContentView
{
	public DatePickerEntry()
	{
		InitializeComponent();
        Date = DateTime.Today;
	}

    public static readonly BindableProperty DateProperty = BindableProperty.Create(
        nameof(Date),
        typeof(DateTime),
        typeof(DatePickerEntry),
        default,
        BindingMode.TwoWay
        );
    public DateTime Date
    {
        get => (DateTime)GetValue(DateProperty);
        set => SetValue(DateProperty, value);
    }

    public static readonly BindableProperty MaximumDateProperty = BindableProperty.Create(
        nameof(MaximumDate),
        typeof(DateTime),
        typeof(DatePickerEntry),
        default,
        BindingMode.OneWay,
        propertyChanged: HandleMaximumDateChanged
        );
    private static void HandleMaximumDateChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is not DatePickerEntry entry) return;

        entry.txtDate.MaximumDate = (DateTime)newValue;
    }

    public DateTime MaximumDate
    {
        get => (DateTime)GetValue(MaximumDateProperty);
        set => SetValue(MaximumDateProperty, value);
    }
}
