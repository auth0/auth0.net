using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<BrandingThemeBordersButtonsStyleEnum>))]
[Serializable]
public readonly record struct BrandingThemeBordersButtonsStyleEnum : IStringEnum
{
    public static readonly BrandingThemeBordersButtonsStyleEnum Pill = new(Values.Pill);

    public static readonly BrandingThemeBordersButtonsStyleEnum Rounded = new(Values.Rounded);

    public static readonly BrandingThemeBordersButtonsStyleEnum Sharp = new(Values.Sharp);

    public BrandingThemeBordersButtonsStyleEnum(string value)
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
    public static BrandingThemeBordersButtonsStyleEnum FromCustom(string value)
    {
        return new BrandingThemeBordersButtonsStyleEnum(value);
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

    public static bool operator ==(BrandingThemeBordersButtonsStyleEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BrandingThemeBordersButtonsStyleEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BrandingThemeBordersButtonsStyleEnum value) =>
        value.Value;

    public static explicit operator BrandingThemeBordersButtonsStyleEnum(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Pill = "pill";

        public const string Rounded = "rounded";

        public const string Sharp = "sharp";
    }
}
