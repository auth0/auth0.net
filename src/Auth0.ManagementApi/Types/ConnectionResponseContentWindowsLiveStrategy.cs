using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ConnectionResponseContentWindowsLiveStrategy.ConnectionResponseContentWindowsLiveStrategySerializer)
)]
[Serializable]
public readonly record struct ConnectionResponseContentWindowsLiveStrategy : IStringEnum
{
    public static readonly ConnectionResponseContentWindowsLiveStrategy Windowslive = new(
        Values.Windowslive
    );

    public ConnectionResponseContentWindowsLiveStrategy(string value)
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
    public static ConnectionResponseContentWindowsLiveStrategy FromCustom(string value)
    {
        return new ConnectionResponseContentWindowsLiveStrategy(value);
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

    public static bool operator ==(
        ConnectionResponseContentWindowsLiveStrategy value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ConnectionResponseContentWindowsLiveStrategy value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionResponseContentWindowsLiveStrategy value) =>
        value.Value;

    public static explicit operator ConnectionResponseContentWindowsLiveStrategy(string value) =>
        new(value);

    internal class ConnectionResponseContentWindowsLiveStrategySerializer
        : JsonConverter<ConnectionResponseContentWindowsLiveStrategy>
    {
        public override ConnectionResponseContentWindowsLiveStrategy Read(
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
            return new ConnectionResponseContentWindowsLiveStrategy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionResponseContentWindowsLiveStrategy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConnectionResponseContentWindowsLiveStrategy ReadAsPropertyName(
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
            return new ConnectionResponseContentWindowsLiveStrategy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConnectionResponseContentWindowsLiveStrategy value,
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
        public const string Windowslive = "windowslive";
    }
}
