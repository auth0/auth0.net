using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ConnectionResponseContentPaypalSandboxStrategy.ConnectionResponseContentPaypalSandboxStrategySerializer)
)]
[Serializable]
public readonly record struct ConnectionResponseContentPaypalSandboxStrategy : IStringEnum
{
    public static readonly ConnectionResponseContentPaypalSandboxStrategy PaypalSandbox = new(
        Values.PaypalSandbox
    );

    public ConnectionResponseContentPaypalSandboxStrategy(string value)
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
    public static ConnectionResponseContentPaypalSandboxStrategy FromCustom(string value)
    {
        return new ConnectionResponseContentPaypalSandboxStrategy(value);
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
        ConnectionResponseContentPaypalSandboxStrategy value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ConnectionResponseContentPaypalSandboxStrategy value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionResponseContentPaypalSandboxStrategy value) =>
        value.Value;

    public static explicit operator ConnectionResponseContentPaypalSandboxStrategy(string value) =>
        new(value);

    internal class ConnectionResponseContentPaypalSandboxStrategySerializer
        : JsonConverter<ConnectionResponseContentPaypalSandboxStrategy>
    {
        public override ConnectionResponseContentPaypalSandboxStrategy Read(
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
            return new ConnectionResponseContentPaypalSandboxStrategy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionResponseContentPaypalSandboxStrategy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConnectionResponseContentPaypalSandboxStrategy ReadAsPropertyName(
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
            return new ConnectionResponseContentPaypalSandboxStrategy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConnectionResponseContentPaypalSandboxStrategy value,
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
        public const string PaypalSandbox = "paypal-sandbox";
    }
}
