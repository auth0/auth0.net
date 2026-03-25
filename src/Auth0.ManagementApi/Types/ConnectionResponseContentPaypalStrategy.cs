using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ConnectionResponseContentPaypalStrategy.ConnectionResponseContentPaypalStrategySerializer)
)]
[Serializable]
public readonly record struct ConnectionResponseContentPaypalStrategy : IStringEnum
{
    public static readonly ConnectionResponseContentPaypalStrategy Paypal = new(Values.Paypal);

    public ConnectionResponseContentPaypalStrategy(string value)
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
    public static ConnectionResponseContentPaypalStrategy FromCustom(string value)
    {
        return new ConnectionResponseContentPaypalStrategy(value);
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

    public static bool operator ==(ConnectionResponseContentPaypalStrategy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionResponseContentPaypalStrategy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionResponseContentPaypalStrategy value) =>
        value.Value;

    public static explicit operator ConnectionResponseContentPaypalStrategy(string value) =>
        new(value);

    internal class ConnectionResponseContentPaypalStrategySerializer
        : JsonConverter<ConnectionResponseContentPaypalStrategy>
    {
        public override ConnectionResponseContentPaypalStrategy Read(
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
            return new ConnectionResponseContentPaypalStrategy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionResponseContentPaypalStrategy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConnectionResponseContentPaypalStrategy ReadAsPropertyName(
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
            return new ConnectionResponseContentPaypalStrategy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConnectionResponseContentPaypalStrategy value,
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
        public const string Paypal = "paypal";
    }
}
