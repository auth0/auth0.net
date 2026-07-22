using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(BrandingThemeIdentifiersPhoneDisplayMaskingEnum.BrandingThemeIdentifiersPhoneDisplayMaskingEnumSerializer)
)]
[Serializable]
public readonly record struct BrandingThemeIdentifiersPhoneDisplayMaskingEnum : IStringEnum
{
    public static readonly BrandingThemeIdentifiersPhoneDisplayMaskingEnum HideCountryCode = new(
        Values.HideCountryCode
    );

    public static readonly BrandingThemeIdentifiersPhoneDisplayMaskingEnum MaskDigits = new(
        Values.MaskDigits
    );

    public static readonly BrandingThemeIdentifiersPhoneDisplayMaskingEnum ShowAll = new(
        Values.ShowAll
    );

    public BrandingThemeIdentifiersPhoneDisplayMaskingEnum(string value)
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
    public static BrandingThemeIdentifiersPhoneDisplayMaskingEnum FromCustom(string value)
    {
        return new BrandingThemeIdentifiersPhoneDisplayMaskingEnum(value);
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
        BrandingThemeIdentifiersPhoneDisplayMaskingEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BrandingThemeIdentifiersPhoneDisplayMaskingEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(BrandingThemeIdentifiersPhoneDisplayMaskingEnum value) =>
        value.Value;

    public static explicit operator BrandingThemeIdentifiersPhoneDisplayMaskingEnum(string value) =>
        new(value);

    internal class BrandingThemeIdentifiersPhoneDisplayMaskingEnumSerializer
        : JsonConverter<BrandingThemeIdentifiersPhoneDisplayMaskingEnum>
    {
        public override BrandingThemeIdentifiersPhoneDisplayMaskingEnum Read(
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
            return new BrandingThemeIdentifiersPhoneDisplayMaskingEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BrandingThemeIdentifiersPhoneDisplayMaskingEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BrandingThemeIdentifiersPhoneDisplayMaskingEnum ReadAsPropertyName(
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
            return new BrandingThemeIdentifiersPhoneDisplayMaskingEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BrandingThemeIdentifiersPhoneDisplayMaskingEnum value,
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
        public const string HideCountryCode = "hide_country_code";

        public const string MaskDigits = "mask_digits";

        public const string ShowAll = "show_all";
    }
}
