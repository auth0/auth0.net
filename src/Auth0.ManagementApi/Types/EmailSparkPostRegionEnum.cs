using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(EmailSparkPostRegionEnum.EmailSparkPostRegionEnumSerializer))]
[Serializable]
public readonly record struct EmailSparkPostRegionEnum : IStringEnum
{
    public static readonly EmailSparkPostRegionEnum Eu = new(Values.Eu);

    public EmailSparkPostRegionEnum(string value)
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
    public static EmailSparkPostRegionEnum FromCustom(string value)
    {
        return new EmailSparkPostRegionEnum(value);
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

    public static bool operator ==(EmailSparkPostRegionEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(EmailSparkPostRegionEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EmailSparkPostRegionEnum value) => value.Value;

    public static explicit operator EmailSparkPostRegionEnum(string value) => new(value);

    internal class EmailSparkPostRegionEnumSerializer : JsonConverter<EmailSparkPostRegionEnum>
    {
        public override EmailSparkPostRegionEnum Read(
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
            return new EmailSparkPostRegionEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EmailSparkPostRegionEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EmailSparkPostRegionEnum ReadAsPropertyName(
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
            return new EmailSparkPostRegionEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EmailSparkPostRegionEnum value,
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
        public const string Eu = "eu";
    }
}
