using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(DefaultConfigEnum.DefaultConfigEnumSerializer))]
[Serializable]
public readonly record struct DefaultConfigEnum : IStringEnum
{
    public static readonly DefaultConfigEnum Tenant = new(Values.Tenant);

    public static readonly DefaultConfigEnum Flag = new(Values.Flag);

    public DefaultConfigEnum(string value)
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
    public static DefaultConfigEnum FromCustom(string value)
    {
        return new DefaultConfigEnum(value);
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

    public static bool operator ==(DefaultConfigEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DefaultConfigEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DefaultConfigEnum value) => value.Value;

    public static explicit operator DefaultConfigEnum(string value) => new(value);

    internal class DefaultConfigEnumSerializer : JsonConverter<DefaultConfigEnum>
    {
        public override DefaultConfigEnum Read(
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
            return new DefaultConfigEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DefaultConfigEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DefaultConfigEnum ReadAsPropertyName(
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
            return new DefaultConfigEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DefaultConfigEnum value,
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
        public const string Tenant = "tenant";

        public const string Flag = "flag";
    }
}
