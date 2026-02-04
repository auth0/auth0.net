using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<BrandingThemeWidgetLogoPositionEnum>))]
[Serializable]
public readonly record struct BrandingThemeWidgetLogoPositionEnum : IStringEnum
{
    public static readonly BrandingThemeWidgetLogoPositionEnum Center = new(Values.Center);

    public static readonly BrandingThemeWidgetLogoPositionEnum Left = new(Values.Left);

    public static readonly BrandingThemeWidgetLogoPositionEnum None = new(Values.None);

    public static readonly BrandingThemeWidgetLogoPositionEnum Right = new(Values.Right);

    public BrandingThemeWidgetLogoPositionEnum(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static BrandingThemeWidgetLogoPositionEnum FromCustom(string value)
    {
        return new BrandingThemeWidgetLogoPositionEnum(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(BrandingThemeWidgetLogoPositionEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BrandingThemeWidgetLogoPositionEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BrandingThemeWidgetLogoPositionEnum value) =>
        value.Value;

    public static explicit operator BrandingThemeWidgetLogoPositionEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Center = "center";

        public const string Left = "left";

        public const string None = "none";

        public const string Right = "right";
    }
}
