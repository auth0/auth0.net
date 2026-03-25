using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ConnectionResponseContentEvernoteStrategy.ConnectionResponseContentEvernoteStrategySerializer)
)]
[Serializable]
public readonly record struct ConnectionResponseContentEvernoteStrategy : IStringEnum
{
    public static readonly ConnectionResponseContentEvernoteStrategy Evernote = new(
        Values.Evernote
    );

    public ConnectionResponseContentEvernoteStrategy(string value)
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
    public static ConnectionResponseContentEvernoteStrategy FromCustom(string value)
    {
        return new ConnectionResponseContentEvernoteStrategy(value);
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
        ConnectionResponseContentEvernoteStrategy value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ConnectionResponseContentEvernoteStrategy value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionResponseContentEvernoteStrategy value) =>
        value.Value;

    public static explicit operator ConnectionResponseContentEvernoteStrategy(string value) =>
        new(value);

    internal class ConnectionResponseContentEvernoteStrategySerializer
        : JsonConverter<ConnectionResponseContentEvernoteStrategy>
    {
        public override ConnectionResponseContentEvernoteStrategy Read(
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
            return new ConnectionResponseContentEvernoteStrategy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionResponseContentEvernoteStrategy value,
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
        public const string Evernote = "evernote";
    }
}
