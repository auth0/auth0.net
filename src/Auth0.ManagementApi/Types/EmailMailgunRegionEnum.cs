using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(EmailMailgunRegionEnum.EmailMailgunRegionEnumSerializer))]
[Serializable]
public readonly record struct EmailMailgunRegionEnum : IStringEnum
{
    public static readonly EmailMailgunRegionEnum Eu = new(Values.Eu);

    public EmailMailgunRegionEnum(string value)
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
    public static EmailMailgunRegionEnum FromCustom(string value)
    {
        return new EmailMailgunRegionEnum(value);
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

    public static bool operator ==(EmailMailgunRegionEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(EmailMailgunRegionEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EmailMailgunRegionEnum value) => value.Value;

    public static explicit operator EmailMailgunRegionEnum(string value) => new(value);

    internal class EmailMailgunRegionEnumSerializer : JsonConverter<EmailMailgunRegionEnum>
    {
        public override EmailMailgunRegionEnum Read(
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
            return new EmailMailgunRegionEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EmailMailgunRegionEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
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
