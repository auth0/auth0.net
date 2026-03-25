using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ConnectionResponseContentSmsStrategy.ConnectionResponseContentSmsStrategySerializer)
)]
[Serializable]
public readonly record struct ConnectionResponseContentSmsStrategy : IStringEnum
{
    public static readonly ConnectionResponseContentSmsStrategy Sms = new(Values.Sms);

    public ConnectionResponseContentSmsStrategy(string value)
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
    public static ConnectionResponseContentSmsStrategy FromCustom(string value)
    {
        return new ConnectionResponseContentSmsStrategy(value);
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

    public static bool operator ==(ConnectionResponseContentSmsStrategy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionResponseContentSmsStrategy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionResponseContentSmsStrategy value) =>
        value.Value;

    public static explicit operator ConnectionResponseContentSmsStrategy(string value) =>
        new(value);

    internal class ConnectionResponseContentSmsStrategySerializer
        : JsonConverter<ConnectionResponseContentSmsStrategy>
    {
        public override ConnectionResponseContentSmsStrategy Read(
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
            return new ConnectionResponseContentSmsStrategy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionResponseContentSmsStrategy value,
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
        public const string Sms = "sms";
    }
}
