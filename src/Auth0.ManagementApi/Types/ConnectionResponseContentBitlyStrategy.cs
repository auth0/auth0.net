using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ConnectionResponseContentBitlyStrategy.ConnectionResponseContentBitlyStrategySerializer)
)]
[Serializable]
public readonly record struct ConnectionResponseContentBitlyStrategy : IStringEnum
{
    public static readonly ConnectionResponseContentBitlyStrategy Bitly = new(Values.Bitly);

    public ConnectionResponseContentBitlyStrategy(string value)
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
    public static ConnectionResponseContentBitlyStrategy FromCustom(string value)
    {
        return new ConnectionResponseContentBitlyStrategy(value);
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

    public static bool operator ==(ConnectionResponseContentBitlyStrategy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionResponseContentBitlyStrategy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionResponseContentBitlyStrategy value) =>
        value.Value;

    public static explicit operator ConnectionResponseContentBitlyStrategy(string value) =>
        new(value);

    internal class ConnectionResponseContentBitlyStrategySerializer
        : JsonConverter<ConnectionResponseContentBitlyStrategy>
    {
        public override ConnectionResponseContentBitlyStrategy Read(
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
            return new ConnectionResponseContentBitlyStrategy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionResponseContentBitlyStrategy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConnectionResponseContentBitlyStrategy ReadAsPropertyName(
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
            return new ConnectionResponseContentBitlyStrategy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConnectionResponseContentBitlyStrategy value,
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
        public const string Bitly = "bitly";
    }
}
