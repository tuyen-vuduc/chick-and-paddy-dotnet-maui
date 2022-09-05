namespace ChickAndPaddy;

[ContentProperty(nameof(Value))]
public class ColorExtension : IMarkupExtension
{
    public Color Value { get; set; }

    public float Alpha { get; set; } = -1;

    public object ProvideValue(IServiceProvider serviceProvider)
    {
        return Value?.WithAlpha(Alpha > 0 && Alpha < 1 ? Alpha : 1);
    }
}

