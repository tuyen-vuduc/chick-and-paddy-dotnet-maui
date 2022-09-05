namespace ChickAndPaddy;

public class DeviceEdgeExtension : IMarkupExtension
{
    public double Ratio { get; set; }

    public DeviceEdge Edge { get; set; }

    public object ProvideValue(IServiceProvider serviceProvider)
    {
        var edgeLength = Edge switch
        {
            DeviceEdge.Width => DeviceDisplay.Current.MainDisplayInfo.Width,
            DeviceEdge.Height => DeviceDisplay.Current.MainDisplayInfo.Height,
            _ => Math.Sqrt(DeviceDisplay.Current.MainDisplayInfo.Width * DeviceDisplay.Current.MainDisplayInfo.Width + DeviceDisplay.Current.MainDisplayInfo.Height * DeviceDisplay.Current.MainDisplayInfo.Height),
        };

        return edgeLength * Ratio / DeviceDisplay.Current.MainDisplayInfo.Density;
    }
}

public enum DeviceEdge
{
    Height,
    Width,
    Diagonal
}
