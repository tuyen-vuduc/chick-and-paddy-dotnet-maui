using CommunityToolkit.Maui.Converters;

namespace ChickAndPaddy;

public static class AppConverters
{
    public static readonly RatioValueConverter Ratio = new RatioValueConverter();
    public static readonly IsEqualConverter IsEqual = new IsEqualConverter();
    public static readonly EnumToBoolConverter EnumToBool = new EnumToBoolConverter();
    public static readonly AllTrueValueConverter AllTrue = new AllTrueValueConverter();
}

