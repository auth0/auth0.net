using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(BrandingThemeIdentifiersPhoneDisplayFormattingEnum.BrandingThemeIdentifiersPhoneDisplayFormattingEnumSerializer)
)]
[Serializable]
public readonly record struct BrandingThemeIdentifiersPhoneDisplayFormattingEnum : IStringEnum
{
    public static readonly BrandingThemeIdentifiersPhoneDisplayFormattingEnum International = new(
        Values.International
    );

    public static readonly BrandingThemeIdentifiersPhoneDisplayFormattingEnum Regional = new(
        Values.Regional
    );

    public BrandingThemeIdentifiersPhoneDisplayFormattingEnum(string value)
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
    public static BrandingThemeIdentifiersPhoneDisplayFormattingEnum FromCustom(string value)
    {
        return new BrandingThemeIdentifiersPhoneDisplayFormattingEnum(value);
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
        BrandingThemeIdentifiersPhoneDisplayFormattingEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BrandingThemeIdentifiersPhoneDisplayFormattingEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        BrandingThemeIdentifiersPhoneDisplayFormattingEnum value
    ) => value.Value;

    public static explicit operator BrandingThemeIdentifiersPhoneDisplayFormattingEnum(
        string value
    ) => new(value);

    internal class BrandingThemeIdentifiersPhoneDisplayFormattingEnumSerializer
        : JsonConverter<BrandingThemeIdentifiersPhoneDisplayFormattingEnum>
    {
        public override BrandingThemeIdentifiersPhoneDisplayFormattingEnum Read(
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
            return new BrandingThemeIdentifiersPhoneDisplayFormattingEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BrandingThemeIdentifiersPhoneDisplayFormattingEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BrandingThemeIdentifiersPhoneDisplayFormattingEnum ReadAsPropertyName(
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
            return new BrandingThemeIdentifiersPhoneDisplayFormattingEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BrandingThemeIdentifiersPhoneDisplayFormattingEnum value,
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
        public const string International = "international";

        public const string Regional = "regional";
    }
}
