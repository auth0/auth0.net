using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ConnectionResponseContentAppleStrategy.ConnectionResponseContentAppleStrategySerializer)
)]
[Serializable]
public readonly record struct ConnectionResponseContentAppleStrategy : IStringEnum
{
    public static readonly ConnectionResponseContentAppleStrategy Apple = new(Values.Apple);

    public ConnectionResponseContentAppleStrategy(string value)
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
    public static ConnectionResponseContentAppleStrategy FromCustom(string value)
    {
        return new ConnectionResponseContentAppleStrategy(value);
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

    public static bool operator ==(ConnectionResponseContentAppleStrategy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionResponseContentAppleStrategy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionResponseContentAppleStrategy value) =>
        value.Value;

    public static explicit operator ConnectionResponseContentAppleStrategy(string value) =>
        new(value);

    internal class ConnectionResponseContentAppleStrategySerializer
        : JsonConverter<ConnectionResponseContentAppleStrategy>
    {
        public override ConnectionResponseContentAppleStrategy Read(
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
            return new ConnectionResponseContentAppleStrategy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionResponseContentAppleStrategy value,
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
        public const string Apple = "apple";
    }
}
