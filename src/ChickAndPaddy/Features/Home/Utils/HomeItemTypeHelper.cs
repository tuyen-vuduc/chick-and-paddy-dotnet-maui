using System;
namespace ChickAndPaddy;

public static class HomeItemTypeHelper
{
	public static readonly BindableProperty HomeItemTypeProperty = BindableProperty.CreateAttached(
		"HomeItemType",
		typeof(HomeItemType),
		typeof(HomeItemTypeHelper),
		default,
		BindingMode.OneWay
	);

    public static HomeItemType GetHomeItemType(BindableObject bindableObject) => (HomeItemType)bindableObject.GetValue(HomeItemTypeProperty);
    public static void SetHomeItemType(BindableObject bindableObject, HomeItemType homeItemType) => bindableObject.SetValue(HomeItemTypeProperty, homeItemType);
}

