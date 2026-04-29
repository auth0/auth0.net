using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(BrandingPhoneFormattingEnum.BrandingPhoneFormattingEnumSerializer))]
[Serializable]
public readonly record struct BrandingPhoneFormattingEnum : IStringEnum
{
    public static readonly BrandingPhoneFormattingEnum Regional = new(Values.Regional);

    public static readonly BrandingPhoneFormattingEnum International = new(Values.International);

    public BrandingPhoneFormattingEnum(string value)
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
    public static BrandingPhoneFormattingEnum FromCustom(string value)
    {
        return new BrandingPhoneFormattingEnum(value);
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

    public static bool operator ==(BrandingPhoneFormattingEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BrandingPhoneFormattingEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BrandingPhoneFormattingEnum value) => value.Value;

    public static explicit operator BrandingPhoneFormattingEnum(string value) => new(value);

    internal class BrandingPhoneFormattingEnumSerializer
        : JsonConverter<BrandingPhoneFormattingEnum>
    {
        public override BrandingPhoneFormattingEnum Read(
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
            return new BrandingPhoneFormattingEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BrandingPhoneFormattingEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BrandingPhoneFormattingEnum ReadAsPropertyName(
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
            return new BrandingPhoneFormattingEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BrandingPhoneFormattingEnum value,
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
        public const string Regional = "regional";

        public const string International = "international";
    }
}
