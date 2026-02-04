using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<BrandingThemeFontLinksStyleEnum>))]
[Serializable]
public readonly record struct BrandingThemeFontLinksStyleEnum : IStringEnum
{
    public static readonly BrandingThemeFontLinksStyleEnum Normal = new(Values.Normal);

    public static readonly BrandingThemeFontLinksStyleEnum Underlined = new(Values.Underlined);

    public BrandingThemeFontLinksStyleEnum(string value)
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
    public static BrandingThemeFontLinksStyleEnum FromCustom(string value)
    {
        return new BrandingThemeFontLinksStyleEnum(value);
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

    public static bool operator ==(BrandingThemeFontLinksStyleEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BrandingThemeFontLinksStyleEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BrandingThemeFontLinksStyleEnum value) => value.Value;

    public static explicit operator BrandingThemeFontLinksStyleEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Normal = "normal";

        public const string Underlined = "underlined";
    }
}
