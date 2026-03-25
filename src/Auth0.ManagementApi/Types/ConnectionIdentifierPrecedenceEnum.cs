using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ConnectionIdentifierPrecedenceEnum.ConnectionIdentifierPrecedenceEnumSerializer)
)]
[Serializable]
public readonly record struct ConnectionIdentifierPrecedenceEnum : IStringEnum
{
    public static readonly ConnectionIdentifierPrecedenceEnum Email = new(Values.Email);

    public static readonly ConnectionIdentifierPrecedenceEnum PhoneNumber = new(Values.PhoneNumber);

    public static readonly ConnectionIdentifierPrecedenceEnum Username = new(Values.Username);

    public ConnectionIdentifierPrecedenceEnum(string value)
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
    public static ConnectionIdentifierPrecedenceEnum FromCustom(string value)
    {
        return new ConnectionIdentifierPrecedenceEnum(value);
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

    public static bool operator ==(ConnectionIdentifierPrecedenceEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionIdentifierPrecedenceEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionIdentifierPrecedenceEnum value) => value.Value;

    public static explicit operator ConnectionIdentifierPrecedenceEnum(string value) => new(value);

    internal class ConnectionIdentifierPrecedenceEnumSerializer
        : JsonConverter<ConnectionIdentifierPrecedenceEnum>
    {
        public override ConnectionIdentifierPrecedenceEnum Read(
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
            return new ConnectionIdentifierPrecedenceEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionIdentifierPrecedenceEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConnectionIdentifierPrecedenceEnum ReadAsPropertyName(
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
            return new ConnectionIdentifierPrecedenceEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConnectionIdentifierPrecedenceEnum value,
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
        public const string Email = "email";

        public const string PhoneNumber = "phone_number";

        public const string Username = "username";
    }
}
