using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ConnectionResponseContentAolStrategy.ConnectionResponseContentAolStrategySerializer)
)]
[Serializable]
public readonly record struct ConnectionResponseContentAolStrategy : IStringEnum
{
    public static readonly ConnectionResponseContentAolStrategy Aol = new(Values.Aol);

    public ConnectionResponseContentAolStrategy(string value)
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
    public static ConnectionResponseContentAolStrategy FromCustom(string value)
    {
        return new ConnectionResponseContentAolStrategy(value);
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

    public static bool operator ==(ConnectionResponseContentAolStrategy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionResponseContentAolStrategy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionResponseContentAolStrategy value) =>
        value.Value;

    public static explicit operator ConnectionResponseContentAolStrategy(string value) =>
        new(value);

    internal class ConnectionResponseContentAolStrategySerializer
        : JsonConverter<ConnectionResponseContentAolStrategy>
    {
        public override ConnectionResponseContentAolStrategy Read(
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
            return new ConnectionResponseContentAolStrategy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionResponseContentAolStrategy value,
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
        public const string Aol = "aol";
    }
}
