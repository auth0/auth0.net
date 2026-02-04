using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<BrandingThemePageBackgroundPageLayoutEnum>))]
[Serializable]
public readonly record struct BrandingThemePageBackgroundPageLayoutEnum : IStringEnum
{
    public static readonly BrandingThemePageBackgroundPageLayoutEnum Center = new(Values.Center);

    public static readonly BrandingThemePageBackgroundPageLayoutEnum Left = new(Values.Left);

    public static readonly BrandingThemePageBackgroundPageLayoutEnum Right = new(Values.Right);

    public BrandingThemePageBackgroundPageLayoutEnum(string value)
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
    public static BrandingThemePageBackgroundPageLayoutEnum FromCustom(string value)
    {
        return new BrandingThemePageBackgroundPageLayoutEnum(value);
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
        BrandingThemePageBackgroundPageLayoutEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BrandingThemePageBackgroundPageLayoutEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(BrandingThemePageBackgroundPageLayoutEnum value) =>
        value.Value;

    public static explicit operator BrandingThemePageBackgroundPageLayoutEnum(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Center = "center";

        public const string Left = "left";

        public const string Right = "right";
    }
}
