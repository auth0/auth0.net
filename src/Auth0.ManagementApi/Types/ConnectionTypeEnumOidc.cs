using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(ConnectionTypeEnumOidc.ConnectionTypeEnumOidcSerializer))]
[Serializable]
public readonly record struct ConnectionTypeEnumOidc : IStringEnum
{
    public static readonly ConnectionTypeEnumOidc BackChannel = new(Values.BackChannel);

    public static readonly ConnectionTypeEnumOidc FrontChannel = new(Values.FrontChannel);

    public ConnectionTypeEnumOidc(string value)
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
    public static ConnectionTypeEnumOidc FromCustom(string value)
    {
        return new ConnectionTypeEnumOidc(value);
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

    public static bool operator ==(ConnectionTypeEnumOidc value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionTypeEnumOidc value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionTypeEnumOidc value) => value.Value;

    public static explicit operator ConnectionTypeEnumOidc(string value) => new(value);

    internal class ConnectionTypeEnumOidcSerializer : JsonConverter<ConnectionTypeEnumOidc>
    {
        public override ConnectionTypeEnumOidc Read(
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
            return new ConnectionTypeEnumOidc(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionTypeEnumOidc value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConnectionTypeEnumOidc ReadAsPropertyName(
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
            return new ConnectionTypeEnumOidc(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConnectionTypeEnumOidc value,
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
        public const string BackChannel = "back_channel";

        public const string FrontChannel = "front_channel";
    }
}
