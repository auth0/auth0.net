using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ConnectionResponseContentThirtySevenSignalsStrategy.ConnectionResponseContentThirtySevenSignalsStrategySerializer)
)]
[Serializable]
public readonly record struct ConnectionResponseContentThirtySevenSignalsStrategy : IStringEnum
{
    public static readonly ConnectionResponseContentThirtySevenSignalsStrategy Thirtysevensignals =
        new(Values.Thirtysevensignals);

    public ConnectionResponseContentThirtySevenSignalsStrategy(string value)
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
    public static ConnectionResponseContentThirtySevenSignalsStrategy FromCustom(string value)
    {
        return new ConnectionResponseContentThirtySevenSignalsStrategy(value);
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
        ConnectionResponseContentThirtySevenSignalsStrategy value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ConnectionResponseContentThirtySevenSignalsStrategy value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ConnectionResponseContentThirtySevenSignalsStrategy value
    ) => value.Value;

    public static explicit operator ConnectionResponseContentThirtySevenSignalsStrategy(
        string value
    ) => new(value);

    internal class ConnectionResponseContentThirtySevenSignalsStrategySerializer
        : JsonConverter<ConnectionResponseContentThirtySevenSignalsStrategy>
    {
        public override ConnectionResponseContentThirtySevenSignalsStrategy Read(
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
            return new ConnectionResponseContentThirtySevenSignalsStrategy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionResponseContentThirtySevenSignalsStrategy value,
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
        public const string Thirtysevensignals = "thirtysevensignals";
    }
}
