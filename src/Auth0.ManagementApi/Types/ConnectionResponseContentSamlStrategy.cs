using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ConnectionResponseContentSamlStrategy.ConnectionResponseContentSamlStrategySerializer)
)]
[Serializable]
public readonly record struct ConnectionResponseContentSamlStrategy : IStringEnum
{
    public static readonly ConnectionResponseContentSamlStrategy Samlp = new(Values.Samlp);

    public ConnectionResponseContentSamlStrategy(string value)
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
    public static ConnectionResponseContentSamlStrategy FromCustom(string value)
    {
        return new ConnectionResponseContentSamlStrategy(value);
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

    public static bool operator ==(ConnectionResponseContentSamlStrategy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionResponseContentSamlStrategy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionResponseContentSamlStrategy value) =>
        value.Value;

    public static explicit operator ConnectionResponseContentSamlStrategy(string value) =>
        new(value);

    internal class ConnectionResponseContentSamlStrategySerializer
        : JsonConverter<ConnectionResponseContentSamlStrategy>
    {
        public override ConnectionResponseContentSamlStrategy Read(
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
            return new ConnectionResponseContentSamlStrategy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionResponseContentSamlStrategy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConnectionResponseContentSamlStrategy ReadAsPropertyName(
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
            return new ConnectionResponseContentSamlStrategy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConnectionResponseContentSamlStrategy value,
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
        public const string Samlp = "samlp";
    }
}
