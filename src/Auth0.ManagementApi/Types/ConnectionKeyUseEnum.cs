using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(ConnectionKeyUseEnum.ConnectionKeyUseEnumSerializer))]
[Serializable]
public readonly record struct ConnectionKeyUseEnum : IStringEnum
{
    public static readonly ConnectionKeyUseEnum Encryption = new(Values.Encryption);

    public static readonly ConnectionKeyUseEnum Signing = new(Values.Signing);

    public ConnectionKeyUseEnum(string value)
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
    public static ConnectionKeyUseEnum FromCustom(string value)
    {
        return new ConnectionKeyUseEnum(value);
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

    public static bool operator ==(ConnectionKeyUseEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionKeyUseEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionKeyUseEnum value) => value.Value;

    public static explicit operator ConnectionKeyUseEnum(string value) => new(value);

    internal class ConnectionKeyUseEnumSerializer : JsonConverter<ConnectionKeyUseEnum>
    {
        public override ConnectionKeyUseEnum Read(
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
            return new ConnectionKeyUseEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionKeyUseEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConnectionKeyUseEnum ReadAsPropertyName(
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
            return new ConnectionKeyUseEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConnectionKeyUseEnum value,
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
        public const string Encryption = "encryption";

        public const string Signing = "signing";
    }
}
