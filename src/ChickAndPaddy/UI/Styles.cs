using Microsoft.Maui.Controls.Shapes;

namespace ChickAndPaddy;


public partial class Styles
{
    public readonly static Shadow Shadow1 = new Shadow()
    {
        Offset = new Point(0, 4),
        Brush = new SolidColorBrush(AppColors.Purple),
        Opacity = 0.1f
    };
    public readonly static Shadow Shadow2 = new Shadow()
    {
        Offset = new Point(0, 4),
        Brush = new SolidColorBrush(AppColors.Purple),
        Opacity = 0.1f
    };

    public static readonly Style BorderMd = CreateStyle<Border>()
        .Set(Border.StrokeProperty, AppColors.Green)
        .Set(Border.StrokeThicknessProperty, 1)
        .Set(Border.StrokeShapeProperty, new RoundRectangle {
                                            CornerRadius = new CornerRadius(16)
                                        });

    static readonly Style ButtonBase = CreateStyle<Button>()
        .Set(VisualElement.BackgroundColorProperty, AppColors.Purple)
        .Set(Button.TextColorProperty, AppColors.Secondary1)
        .Set(VisualElement.MaximumHeightRequestProperty, Dimens.ButtonHeight)
        .Set(VisualElement.MaximumWidthRequestProperty, Dimens.ButtonWidth)
        .Set(Button.CornerRadiusProperty, Dimens.ButtonCornerRadius)
        .Set(Button.FontSizeProperty, Dimens.FontSizeT5)
        .Set(Button.FontFamilyProperty, FontNames.ArchiaSemiBold);

    public static readonly Style ButtonPrimary = CreateStyle<Button>()
        .BaseOn(ButtonBase)
        .Set(VisualElement.BackgroundColorProperty, AppColors.Purple)
        .Set(Button.TextColorProperty, AppColors.Secondary1)
        .Set(VisualElement.MinimumHeightRequestProperty, Dimens.ButtonHeight)
        .Set(VisualElement.HeightRequestProperty, Dimens.ButtonHeight)
        .Set(VisualElement.WidthRequestProperty, Dimens.ButtonWidth);

    public static readonly Style ButtonSecondary = CreateStyle<Button>()
        .BaseOn(ButtonPrimary)
        .Set(VisualElement.BackgroundColorProperty, AppColors.Grey20)
        .Set(Button.TextColorProperty, AppColors.Grey50);

    public static readonly Style ButtonFlat = CreateStyle<Button>()
        .BaseOn(ButtonPrimary)
        .Set(VisualElement.BackgroundColorProperty, Colors.Transparent)
        .Set(Button.TextColorProperty, AppColors.Grey50)
        ;

    public static readonly Style ButtonAccent = CreateStyle<Button>()
        .BaseOn(ButtonPrimary)
        .Set(VisualElement.BackgroundColorProperty, AppColors.Pink);

    public static readonly Style ButtonPrimarySm = CreateStyle<Button>()
        .BaseOn(ButtonBase)
        .Set(VisualElement.HeightRequestProperty, Dimens.ButtonHeightSm)
        .Set(VisualElement.MaximumHeightRequestProperty, Dimens.ButtonHeightSm)
        .Set(VisualElement.MinimumHeightRequestProperty, Dimens.ButtonHeightSm)
        .Set(VisualElement.MaximumWidthRequestProperty, Dimens.ButtonWidth)
        .Set(Button.TextColorProperty, AppColors.White)
        ;
    public static readonly Style ButtonSecondarySm = CreateStyle<Button>()
        .BaseOn(ButtonPrimarySm)
        .Set(VisualElement.BackgroundColorProperty, AppColors.Grey20)
        .Set(Button.TextColorProperty, AppColors.Grey50);

    public static readonly Style ButtonFlatSm = CreateStyle<Button>()
        .BaseOn(ButtonPrimarySm)
        .Set(VisualElement.BackgroundColorProperty, Colors.Transparent)
        .Set(Button.TextColorProperty, AppColors.Grey50)
        ;
    public static readonly Style ButtonAccentSm = CreateStyle<Button>()
        .BaseOn(ButtonPrimarySm)
        .Set(VisualElement.BackgroundColorProperty, AppColors.Pink)
        ;

    public static readonly Style ButtonPrimaryXs = CreateStyle<Button>()
        .BaseOn(ButtonBase)
        .Set(VisualElement.HeightRequestProperty, Dimens.ButtonHeightXs)
        .Set(VisualElement.MaximumHeightRequestProperty, Dimens.ButtonHeightXs)
        .Set(VisualElement.MinimumHeightRequestProperty, Dimens.ButtonHeightXs)
        .Set(VisualElement.MaximumWidthRequestProperty, Dimens.ButtonWidth)
        .Set(Button.CornerRadiusProperty, Dimens.ButtonCornerRadiusXs)
        .Set(Button.FontSizeProperty, Dimens.FontSizeT6)
        .Set(Button.TextColorProperty, AppColors.Grey50)
        ;
    public static readonly Style ButtonFlatXs = CreateStyle<Button>()
        .BaseOn(ButtonPrimaryXs)
        .Set(VisualElement.BackgroundColorProperty, Colors.Transparent)
        .Set(Button.TextColorProperty, AppColors.Grey50)
        ;
    public static readonly Style ButtonAccentXs = CreateStyle<Button>()
        .BaseOn(ButtonPrimaryXs)
        .Set(VisualElement.BackgroundColorProperty, AppColors.Pink)
        ;
    public static readonly Style ButtonOutlinedXs = CreateStyle<Button>()
        .BaseOn(ButtonPrimaryXs)
        .Set(Button.FontSizeProperty, Dimens.FontSizeT6)
        .Set(Button.TextColorProperty, AppColors.Pink)
        .Set(Button.BorderColorProperty, AppColors.Pink)
        .Set(Button.BorderWidthProperty, 1)
        .Set(Button.BackgroundColorProperty, Colors.Transparent)
        ;

}

public partial class Styles
{
    static readonly Color textPrimaryColor = AppColors.Black;

    public static readonly Style Title1 = CreateStyle<Label>()
        .Set(VisualElement.BackgroundColorProperty, Colors.Transparent)
        .Set(Label.TextColorProperty, textPrimaryColor)
        .Set(Label.FontSizeProperty, Dimens.FontSizeT1)
        .Set(Label.FontFamilyProperty, FontNames.ArchiaSemiBold)
        //.Set(Label.LineHeightProperty, Dimens.LineHeightT1)
        ;

    public static readonly Style Title2 = CreateStyle<Label>()
        .Set(VisualElement.BackgroundColorProperty, Colors.Transparent)
        .Set(Label.TextColorProperty, textPrimaryColor)
        .Set(Label.FontSizeProperty, Dimens.FontSizeT2)
        .Set(Label.FontFamilyProperty, FontNames.ArchiaSemiBold)
        //.Set(Label.LineHeightProperty, Dimens.LineHeightT2)
        ;

    public static readonly Style Title3 = CreateStyle<Label>()
        .Set(VisualElement.BackgroundColorProperty, Colors.Transparent)
        .Set(Label.TextColorProperty, textPrimaryColor)
        .Set(Label.FontSizeProperty, Dimens.FontSizeT3)
        .Set(Label.FontFamilyProperty, FontNames.ArchiaSemiBold)
        //.Set(Label.LineHeightProperty, Dimens.LineHeightT3)
        ;

    public static readonly Style Title4 = CreateStyle<Label>()
        .Set(VisualElement.BackgroundColorProperty, Colors.Transparent)
        .Set(Label.TextColorProperty, textPrimaryColor)
        .Set(Label.FontSizeProperty, Dimens.FontSizeT4)
        .Set(Label.FontFamilyProperty, FontNames.ArchiaSemiBold)
        //.Set(Label.LineHeightProperty, Dimens.LineHeightT4)
        ;

    public static readonly Style Title5 = CreateStyle<Label>()
        .Set(VisualElement.BackgroundColorProperty, Colors.Transparent)
        .Set(Label.TextColorProperty, textPrimaryColor)
        .Set(Label.FontSizeProperty, Dimens.FontSizeT5)
        .Set(Label.FontFamilyProperty, FontNames.ArchiaSemiBold)
        //.Set(Label.LineHeightProperty, Dimens.LineHeightT5)
        ;

    public static readonly Style Title6 = CreateStyle<Label>()
        .Set(VisualElement.BackgroundColorProperty, Colors.Transparent)
        .Set(Label.TextColorProperty, textPrimaryColor)
        .Set(Label.FontSizeProperty, Dimens.FontSizeT6)
        .Set(Label.FontFamilyProperty, FontNames.ArchiaSemiBold)
        //.Set(Label.LineHeightProperty, Dimens.LineHeightT6)
        ;

    public static readonly Style Title7 = CreateStyle<Label>()
        .Set(VisualElement.BackgroundColorProperty, Colors.Transparent)
        .Set(Label.TextColorProperty, textPrimaryColor)
        .Set(Label.FontSizeProperty, Dimens.FontSizeT7)
        .Set(Label.FontFamilyProperty, FontNames.ArchiaSemiBold)
        //.Set(Label.LineHeightProperty, Dimens.LineHeightT7)
        ;

    public static readonly Style Subtitle1 = CreateStyle<Label>()
        .Set(VisualElement.BackgroundColorProperty, Colors.Transparent)
        .Set(Label.TextColorProperty, textPrimaryColor)
        .Set(Label.FontSizeProperty, Dimens.FontSizeT1)
        .Set(Label.FontFamilyProperty, FontNames.ArchiaRegular)
        //.Set(Label.LineHeightProperty, Dimens.LineHeightT1)
        ;

    public static readonly Style Subtitle2 = CreateStyle<Label>()
        .Set(VisualElement.BackgroundColorProperty, Colors.Transparent)
        .Set(Label.TextColorProperty, textPrimaryColor)
        .Set(Label.FontSizeProperty, Dimens.FontSizeT2)
        .Set(Label.FontFamilyProperty, FontNames.ArchiaRegular)
        //.Set(Label.LineHeightProperty, Dimens.LineHeightT2)
        ;

    public static readonly Style Subtitle3 = CreateStyle<Label>()
        .Set(VisualElement.BackgroundColorProperty, Colors.Transparent)
        .Set(Label.TextColorProperty, textPrimaryColor)
        .Set(Label.FontSizeProperty, Dimens.FontSizeT3)
        .Set(Label.FontFamilyProperty, FontNames.ArchiaRegular)
        //.Set(Label.LineHeightProperty, Dimens.LineHeightT3)
        ;

    public static readonly Style Subtitle4 = CreateStyle<Label>()
        .Set(VisualElement.BackgroundColorProperty, Colors.Transparent)
        .Set(Label.TextColorProperty, textPrimaryColor)
        .Set(Label.FontSizeProperty, Dimens.FontSizeT4)
        .Set(Label.FontFamilyProperty, FontNames.ArchiaRegular)
        //.Set(Label.LineHeightProperty, Dimens.LineHeightT4)
        ;

    public static readonly Style Subtitle5 = CreateStyle<Label>()
        .Set(VisualElement.BackgroundColorProperty, Colors.Transparent)
        .Set(Label.TextColorProperty, textPrimaryColor)
        .Set(Label.FontSizeProperty, Dimens.FontSizeT5)
        .Set(Label.FontFamilyProperty, FontNames.ArchiaRegular)
        //.Set(Label.LineHeightProperty, Dimens.LineHeightT5)
        ;

    public static readonly Style Subtitle6 = CreateStyle<Label>()
        .Set(VisualElement.BackgroundColorProperty, Colors.Transparent)
        .Set(Label.TextColorProperty, textPrimaryColor)
        .Set(Label.FontSizeProperty, Dimens.FontSizeT6)
        .Set(Label.FontFamilyProperty, FontNames.ArchiaRegular)
        //.Set(Label.LineHeightProperty, Dimens.LineHeightT6)
        ;

    public static readonly Style Subtitle7 = CreateStyle<Label>()
        .Set(VisualElement.BackgroundColorProperty, Colors.Transparent)
        .Set(Label.TextColorProperty, textPrimaryColor)
        .Set(Label.FontSizeProperty, Dimens.FontSizeT7)
        .Set(Label.FontFamilyProperty, FontNames.ArchiaRegular)
        //.Set(Label.LineHeightProperty, Dimens.LineHeightT6)
        ;

    public static readonly Style Body1 = CreateStyle<Label>()
        .Set(VisualElement.BackgroundColorProperty, Colors.Transparent)
        .Set(Label.TextColorProperty, textPrimaryColor)
        .Set(Label.FontSizeProperty, Dimens.FontSizeT5)
        .Set(Label.FontFamilyProperty, FontNames.ArchiaRegular)
        //.Set(Label.LineHeightProperty, Dimens.LineHeightT3)
        ;

    public static readonly Style Body2 = CreateStyle<Label>()
        .Set(VisualElement.BackgroundColorProperty, Colors.Transparent)
        .Set(Label.TextColorProperty, textPrimaryColor)
        .Set(Label.FontSizeProperty, Dimens.FontSizeT6)
        .Set(Label.FontFamilyProperty, FontNames.ArchiaRegular)
        //.Set(Label.LineHeightProperty, Dimens.LineHeightT6)
        ;

    public static readonly Style Body3 = CreateStyle<Label>()
        .Set(VisualElement.BackgroundColorProperty, Colors.Transparent)
        .Set(Label.TextColorProperty, textPrimaryColor)
        .Set(Label.FontSizeProperty, Dimens.FontSizeT7)
        .Set(Label.FontFamilyProperty, FontNames.ArchiaRegular)
        //.Set(Label.LineHeightProperty, Dimens.LineHeightT7)
        ;

    public static readonly Style Body4 = CreateStyle<Label>()
        .Set(VisualElement.BackgroundColorProperty, Colors.Transparent)
        .Set(Label.TextColorProperty, textPrimaryColor)
        .Set(Label.FontSizeProperty, Dimens.FontSizeT8)
        .Set(Label.FontFamilyProperty, FontNames.ArchiaRegular)
        //.Set(Label.LineHeightProperty, Dimens.LineHeightT8)
        ;
}


public static partial class Styles
{
    public static Style CreateStyle<T>()
    {
        return new Style(typeof(T));
    }

    public static Style BaseOn(this Style style, Style basedOn)
    {
        style.BasedOn = basedOn;
        return style;
    }

    public static Style Set(this Style style, BindableProperty property, object value)
    {
        style.Setters.Add(new Setter
        {
            Property = property,
            Value = value
        });
        return style;
    }

    public static Style BindTrigger(this Style style, Binding binding, object value, params (BindableProperty p, object value)[] setters)
    {
        var dataTrigger = new DataTrigger(style.TargetType)
        {
            Binding = binding,
            Value = value
        };

        for (int i = 0; i < setters.Length; i++)
        {
            dataTrigger.Setters.Add(new Setter
            {
                Property = setters[i].p,
                Value = setters[i].value
            });
        }

        style.Triggers.Add(dataTrigger);

        return style;
    }
}
