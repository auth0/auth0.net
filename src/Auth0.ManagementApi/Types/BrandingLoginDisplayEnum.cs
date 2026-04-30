using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(BrandingLoginDisplayEnum.BrandingLoginDisplayEnumSerializer))]
[Serializable]
public readonly record struct BrandingLoginDisplayEnum : IStringEnum
{
    public static readonly BrandingLoginDisplayEnum Unified = new(Values.Unified);

    public static readonly BrandingLoginDisplayEnum Separate = new(Values.Separate);

    public BrandingLoginDisplayEnum(string value)
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
    public static BrandingLoginDisplayEnum FromCustom(string value)
    {
        return new BrandingLoginDisplayEnum(value);
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

    public static bool operator ==(BrandingLoginDisplayEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BrandingLoginDisplayEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BrandingLoginDisplayEnum value) => value.Value;

    public static explicit operator BrandingLoginDisplayEnum(string value) => new(value);

    internal class BrandingLoginDisplayEnumSerializer : JsonConverter<BrandingLoginDisplayEnum>
    {
        public override BrandingLoginDisplayEnum Read(
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
            return new BrandingLoginDisplayEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BrandingLoginDisplayEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BrandingLoginDisplayEnum ReadAsPropertyName(
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
            return new BrandingLoginDisplayEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BrandingLoginDisplayEnum value,
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
        public const string Unified = "unified";

        public const string Separate = "separate";
    }
}
