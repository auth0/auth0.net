using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<BrandingThemeBordersInputsStyleEnum>))]
[Serializable]
public readonly record struct BrandingThemeBordersInputsStyleEnum : IStringEnum
{
    public static readonly BrandingThemeBordersInputsStyleEnum Pill = new(Values.Pill);

    public static readonly BrandingThemeBordersInputsStyleEnum Rounded = new(Values.Rounded);

    public static readonly BrandingThemeBordersInputsStyleEnum Sharp = new(Values.Sharp);

    public BrandingThemeBordersInputsStyleEnum(string value)
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
    public static BrandingThemeBordersInputsStyleEnum FromCustom(string value)
    {
        return new BrandingThemeBordersInputsStyleEnum(value);
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

    public static bool operator ==(BrandingThemeBordersInputsStyleEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BrandingThemeBordersInputsStyleEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BrandingThemeBordersInputsStyleEnum value) =>
        value.Value;

    public static explicit operator BrandingThemeBordersInputsStyleEnum(string value) => new(value);

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
