using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<BrandingThemeColorsCaptchaWidgetThemeEnum>))]
[Serializable]
public readonly record struct BrandingThemeColorsCaptchaWidgetThemeEnum : IStringEnum
{
    public static readonly BrandingThemeColorsCaptchaWidgetThemeEnum Auto = new(Values.Auto);

    public static readonly BrandingThemeColorsCaptchaWidgetThemeEnum Dark = new(Values.Dark);

    public static readonly BrandingThemeColorsCaptchaWidgetThemeEnum Light = new(Values.Light);

    public BrandingThemeColorsCaptchaWidgetThemeEnum(string value)
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
    public static BrandingThemeColorsCaptchaWidgetThemeEnum FromCustom(string value)
    {
        return new BrandingThemeColorsCaptchaWidgetThemeEnum(value);
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

    public static bool operator ==(
        BrandingThemeColorsCaptchaWidgetThemeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BrandingThemeColorsCaptchaWidgetThemeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(BrandingThemeColorsCaptchaWidgetThemeEnum value) =>
        value.Value;

    public static explicit operator BrandingThemeColorsCaptchaWidgetThemeEnum(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Auto = "auto";

        public const string Dark = "dark";

        public const string Light = "light";
    }
}
