using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(BrandingThemeWidgetSocialButtonsLayoutEnum.BrandingThemeWidgetSocialButtonsLayoutEnumSerializer)
)]
[Serializable]
public readonly record struct BrandingThemeWidgetSocialButtonsLayoutEnum : IStringEnum
{
    public static readonly BrandingThemeWidgetSocialButtonsLayoutEnum Bottom = new(Values.Bottom);

    public static readonly BrandingThemeWidgetSocialButtonsLayoutEnum Top = new(Values.Top);

    public BrandingThemeWidgetSocialButtonsLayoutEnum(string value)
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
    public static BrandingThemeWidgetSocialButtonsLayoutEnum FromCustom(string value)
    {
        return new BrandingThemeWidgetSocialButtonsLayoutEnum(value);
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
        BrandingThemeWidgetSocialButtonsLayoutEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BrandingThemeWidgetSocialButtonsLayoutEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(BrandingThemeWidgetSocialButtonsLayoutEnum value) =>
        value.Value;

    public static explicit operator BrandingThemeWidgetSocialButtonsLayoutEnum(string value) =>
        new(value);

    internal class BrandingThemeWidgetSocialButtonsLayoutEnumSerializer
        : JsonConverter<BrandingThemeWidgetSocialButtonsLayoutEnum>
    {
        public override BrandingThemeWidgetSocialButtonsLayoutEnum Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new BrandingThemeWidgetSocialButtonsLayoutEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BrandingThemeWidgetSocialButtonsLayoutEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BrandingThemeWidgetSocialButtonsLayoutEnum ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new BrandingThemeWidgetSocialButtonsLayoutEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BrandingThemeWidgetSocialButtonsLayoutEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Bottom = "bottom";

        public const string Top = "top";
    }
}
