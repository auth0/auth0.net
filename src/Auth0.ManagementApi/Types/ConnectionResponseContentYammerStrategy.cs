using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ConnectionResponseContentYammerStrategy.ConnectionResponseContentYammerStrategySerializer)
)]
[Serializable]
public readonly record struct ConnectionResponseContentYammerStrategy : IStringEnum
{
    public static readonly ConnectionResponseContentYammerStrategy Yammer = new(Values.Yammer);

    public ConnectionResponseContentYammerStrategy(string value)
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
    public static ConnectionResponseContentYammerStrategy FromCustom(string value)
    {
        return new ConnectionResponseContentYammerStrategy(value);
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

    public static bool operator ==(ConnectionResponseContentYammerStrategy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionResponseContentYammerStrategy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionResponseContentYammerStrategy value) =>
        value.Value;

    public static explicit operator ConnectionResponseContentYammerStrategy(string value) =>
        new(value);

    internal class ConnectionResponseContentYammerStrategySerializer
        : JsonConverter<ConnectionResponseContentYammerStrategy>
    {
        public override ConnectionResponseContentYammerStrategy Read(
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
            return new ConnectionResponseContentYammerStrategy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionResponseContentYammerStrategy value,
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
        public const string Yammer = "yammer";
    }
}
