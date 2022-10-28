namespace ChickAndPaddy;

[ExcludeFromCodeCoverage]
public partial class PinCodeEntry : ContentView
{
    public const int DEFAULT_PIN_LENGTH = 6;

    PinDigitModel[] pinDigits;

    public PinCodeEntry()
	{
		InitializeComponent();

        HandlePinLengthChanged(this, 0, DEFAULT_PIN_LENGTH);
    }

	public static readonly BindableProperty TextProperty = BindableProperty.Create(
		nameof(Text),
		typeof(string),
		typeof(PinCodeEntry),
		default(string),
		BindingMode.TwoWay,
        propertyChanged: HandleTextChanged
	);
    private static void HandleTextChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is not PinCodeEntry entry) return;

        var text = entry.Text?.Trim() ?? string.Empty;

        if (entry.pinDigits?.Length < 0) return;

        for (int i = 0; i < entry.pinDigits.Length; i++)
        {
            if (i >= text.Length)
            {
                entry.pinDigits[i].Digit = PinDigitModel.DEFAULT_PIN_DIGIT;
                continue;
            }

            entry.pinDigits[i].Digit = text[i].ToString();
        }
    }

    public string Text {
		get => (string)GetValue(TextProperty);
		set => SetValue(TextProperty, value);
    }

    public static readonly BindableProperty PinLengthProperty = BindableProperty.Create(
        nameof(PinLength),
        typeof(int),
        typeof(PinCodeEntry),
        DEFAULT_PIN_LENGTH,
        BindingMode.TwoWay,
        propertyChanged: HandlePinLengthChanged
    );
    private static void HandlePinLengthChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is not PinCodeEntry entry) return;

        var pinLength = entry.PinLength;

        if (pinLength < 4)
        {
            entry.PinLength = DEFAULT_PIN_LENGTH;
            return;
        }

        entry.pinDigits = new PinDigitModel[pinLength];
        for (int i = 0; i < pinLength; i++)
        {
            entry.pinDigits[i] = new PinDigitModel();
        }

        BindableLayout.SetItemsSource(entry.dotContainer, entry.pinDigits);
    }

    public int PinLength
    {
        get => (int)GetValue(PinLengthProperty);
        set => SetValue(PinLengthProperty, value);
    }
}

public partial class PinDigitModel : BaseModel
{
    public const string DEFAULT_PIN_DIGIT = " ";

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HasDigit))]
    string digit = DEFAULT_PIN_DIGIT;

    public bool HasDigit => !string.IsNullOrWhiteSpace(Digit);
}