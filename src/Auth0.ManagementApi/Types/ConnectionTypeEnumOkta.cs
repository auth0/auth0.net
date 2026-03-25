using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(ConnectionTypeEnumOkta.ConnectionTypeEnumOktaSerializer))]
[Serializable]
public readonly record struct ConnectionTypeEnumOkta : IStringEnum
{
    public static readonly ConnectionTypeEnumOkta BackChannel = new(Values.BackChannel);

    public ConnectionTypeEnumOkta(string value)
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
    public static ConnectionTypeEnumOkta FromCustom(string value)
    {
        return new ConnectionTypeEnumOkta(value);
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

    public static bool operator ==(ConnectionTypeEnumOkta value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionTypeEnumOkta value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionTypeEnumOkta value) => value.Value;

    public static explicit operator ConnectionTypeEnumOkta(string value) => new(value);

    internal class ConnectionTypeEnumOktaSerializer : JsonConverter<ConnectionTypeEnumOkta>
    {
        public override ConnectionTypeEnumOkta Read(
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
            return new ConnectionTypeEnumOkta(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionTypeEnumOkta value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConnectionTypeEnumOkta ReadAsPropertyName(
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
            return new ConnectionTypeEnumOkta(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConnectionTypeEnumOkta value,
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
    }
}
