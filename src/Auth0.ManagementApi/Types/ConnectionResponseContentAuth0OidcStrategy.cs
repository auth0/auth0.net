using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ConnectionResponseContentAuth0OidcStrategy.ConnectionResponseContentAuth0OidcStrategySerializer)
)]
[Serializable]
public readonly record struct ConnectionResponseContentAuth0OidcStrategy : IStringEnum
{
    public static readonly ConnectionResponseContentAuth0OidcStrategy Auth0Oidc = new(
        Values.Auth0Oidc
    );

    public ConnectionResponseContentAuth0OidcStrategy(string value)
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
    public static ConnectionResponseContentAuth0OidcStrategy FromCustom(string value)
    {
        return new ConnectionResponseContentAuth0OidcStrategy(value);
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
        ConnectionResponseContentAuth0OidcStrategy value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ConnectionResponseContentAuth0OidcStrategy value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionResponseContentAuth0OidcStrategy value) =>
        value.Value;

    public static explicit operator ConnectionResponseContentAuth0OidcStrategy(string value) =>
        new(value);

    internal class ConnectionResponseContentAuth0OidcStrategySerializer
        : JsonConverter<ConnectionResponseContentAuth0OidcStrategy>
    {
        public override ConnectionResponseContentAuth0OidcStrategy Read(
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
            return new ConnectionResponseContentAuth0OidcStrategy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionResponseContentAuth0OidcStrategy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConnectionResponseContentAuth0OidcStrategy ReadAsPropertyName(
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
            return new ConnectionResponseContentAuth0OidcStrategy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConnectionResponseContentAuth0OidcStrategy value,
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
        public const string Auth0Oidc = "auth0-oidc";
    }
}
