using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(ConnectionDpopSigningAlgEnum.ConnectionDpopSigningAlgEnumSerializer))]
[Serializable]
public readonly record struct ConnectionDpopSigningAlgEnum : IStringEnum
{
    public static readonly ConnectionDpopSigningAlgEnum Es256 = new(Values.Es256);

    public static readonly ConnectionDpopSigningAlgEnum Ed25519 = new(Values.Ed25519);

    public ConnectionDpopSigningAlgEnum(string value)
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
    public static ConnectionDpopSigningAlgEnum FromCustom(string value)
    {
        return new ConnectionDpopSigningAlgEnum(value);
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

    public static bool operator ==(ConnectionDpopSigningAlgEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionDpopSigningAlgEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionDpopSigningAlgEnum value) => value.Value;

    public static explicit operator ConnectionDpopSigningAlgEnum(string value) => new(value);

    internal class ConnectionDpopSigningAlgEnumSerializer
        : JsonConverter<ConnectionDpopSigningAlgEnum>
    {
        public override ConnectionDpopSigningAlgEnum Read(
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
            return new ConnectionDpopSigningAlgEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionDpopSigningAlgEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConnectionDpopSigningAlgEnum ReadAsPropertyName(
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
            return new ConnectionDpopSigningAlgEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConnectionDpopSigningAlgEnum value,
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
        public const string Es256 = "ES256";

        public const string Ed25519 = "Ed25519";
    }
}
