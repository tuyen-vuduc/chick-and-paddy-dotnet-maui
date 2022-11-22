using CommunityToolkit.Maui.Converters;

namespace ChickAndPaddy;

public static class AppConverters
{
    public static readonly RatioValueConverter Ratio = new RatioValueConverter();
    public static readonly IsEqualConverter IsEqual = new IsEqualConverter();
    public static readonly EnumToBoolConverter EnumToBool = new EnumToBoolConverter();
    public static readonly AllTrueValueConverter AllTrue = new AllTrueValueConverter();
    public static readonly BoolToOpacityValueConverter BoolToOpacity = new BoolToOpacityValueConverter();
    public static readonly BoolToOpacityValueConverter InversedBoolToOpacity = new BoolToOpacityValueConverter(true);

    public static readonly AllBoolsToOpacityValueConverter AllBoolsToOpacity = new AllBoolsToOpacityValueConverter();
    public static readonly AllBoolsToOpacityValueConverter InversedAllBoolsToOpacity = new AllBoolsToOpacityValueConverter(true);
    public static readonly AnyFalseToOpacityValueConverter AnyFalseToOpacity = new AnyFalseToOpacityValueConverter();

    public static readonly FirstItemValueConverter FirstItem = new FirstItemValueConverter();

    public static readonly IsListNullOrEmptyConverter IsListNullOrEmpty = new IsListNullOrEmptyConverter();
    public static readonly IsListNotNullOrEmptyConverter IsListNotNullOrEmpty = new IsListNotNullOrEmptyConverter();
}

