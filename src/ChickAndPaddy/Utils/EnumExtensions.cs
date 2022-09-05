using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace ChickAndPaddy;

public static class EnumExtensions
{
    //public static IEnumerable<T> GetValues<T>() where T : struct, IConvertible, IFormattable
    //{
    //    return GetValues(typeof(T)).Cast<T>();
    //}

    public static bool Contains<T>(this T @enum, params T[] list) where T : struct, IConvertible, IFormattable
    {
        CheckIsEnum<T>();

        return Contains<T>(@enum, list ?? Enumerable.Empty<T>());
    }

    public static bool Contains<T>(this T @enum, IEnumerable<T> list) where T : struct, IConvertible, IFormattable
    {
        if (list == null)
        {
            return false;
        }

        CheckIsEnum<T>();

        var type = @enum.GetType();

        if (!(@enum is Enum enumValue))
        {
            return false;
        }

        var isFlags = type.GetTypeInfo().GetCustomAttribute<FlagsAttribute>() != null;

        foreach (var item in list)
        {
            if (!(item is Enum enumItem))
            {
                continue;
            }
            if (@enum.Equals(item) || (isFlags && enumValue.HasFlag(enumItem)))
            {
                return true;
            }
        }
        return false;
    }

    public static string GetDescription<T>(this T @enum)
        where T : struct, IConvertible
    {
        if (!(@enum is Enum))
        {
            return string.Empty;
        }

        var type = @enum.GetType();
        var values = Enum.GetValues(type);

        foreach (int val in values)
        {
            if (val != @enum.ToInt32(CultureInfo.InvariantCulture))
            {
                continue;
            }

            var memInfo = type.GetMember(type.GetEnumName(val) ?? string.Empty);

            var descriptionAttribute = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false)
                .FirstOrDefault() as DescriptionAttribute;

            if (descriptionAttribute != null)
            {
                return descriptionAttribute.Description;
            }
        }

        return string.Empty;
    }

    public static string GetDescription(this Enum enumValue)
    {
        var fi = enumValue.GetType().GetField(enumValue.ToString());

        var attributes = fi.GetCustomAttributes(
            typeof(DescriptionAttribute),
            false).OfType<DescriptionAttribute>()
                  .ToList();

        return attributes.Any()
                ? attributes.First().Description
                : enumValue.ToString();
    }

    public static T Parse<T>(string value) where T : struct, IConvertible, IFormattable
    {
        CheckIsEnum<T>();

        return Enum.TryParse<T>(value, out var result) ? result : default(T);
    }

    public static TEnumType GetEnum<TEnumType>(this object parameter)
        where TEnumType : struct
    {
        if (parameter == null)
        {
            return default;
        }

        return (TEnumType)Enum.Parse(typeof(TEnumType), parameter.ToString());
    }

    //static IEnumerable GetValues(Type enumType)
    //{
    //    CheckIsEnum(enumType);

    //    var values = Enum.GetValues(enumType).Cast<Enum>().ToList();


    //    if (values.All(x => GetAttribute<OrderAttribute>(x) == null))
    //    {
    //        return values;
    //    }

    //    {
    //        var orderedValues = values.Where(x => x.GetAttribute<OrderAttribute>() != null).OrderBy(x => x.GetAttribute<OrderAttribute>().Order).ToList();
    //        var unorderedValues = values.Where(x => x.GetAttribute<OrderAttribute>() == null);
    //        orderedValues.AddRange(unorderedValues);
    //        values = orderedValues;
    //    }
    //    return values;
    //}

    static T GetAttribute<T>(this Enum enumValue) where T : Attribute
    {
        if (enumValue == null)
        {
            return null;
        }

        var memberInfo = enumValue.GetType().GetTypeInfo().GetDeclaredField(enumValue.ToString());

        return memberInfo != null ? memberInfo.GetCustomAttribute<T>() : null;
    }

    static void CheckIsEnum(Type type)
    {
        if (!type.GetTypeInfo().IsEnum)
        {
            throw new ArgumentException($"Argument {type.FullName} is not an Enum");
        }
    }

    static void CheckIsEnum<T>()
    {
        CheckIsEnum(typeof(T));
    }
}
