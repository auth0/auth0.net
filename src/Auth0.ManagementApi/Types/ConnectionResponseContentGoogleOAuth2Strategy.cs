using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ConnectionResponseContentGoogleOAuth2Strategy.ConnectionResponseContentGoogleOAuth2StrategySerializer)
)]
[Serializable]
public readonly record struct ConnectionResponseContentGoogleOAuth2Strategy : IStringEnum
{
    public static readonly ConnectionResponseContentGoogleOAuth2Strategy GoogleOauth2 = new(
        Values.GoogleOauth2
    );

    public ConnectionResponseContentGoogleOAuth2Strategy(string value)
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
    public static ConnectionResponseContentGoogleOAuth2Strategy FromCustom(string value)
    {
        return new ConnectionResponseContentGoogleOAuth2Strategy(value);
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
        ConnectionResponseContentGoogleOAuth2Strategy value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ConnectionResponseContentGoogleOAuth2Strategy value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionResponseContentGoogleOAuth2Strategy value) =>
        value.Value;

    public static explicit operator ConnectionResponseContentGoogleOAuth2Strategy(string value) =>
        new(value);

    internal class ConnectionResponseContentGoogleOAuth2StrategySerializer
        : JsonConverter<ConnectionResponseContentGoogleOAuth2Strategy>
    {
        public override ConnectionResponseContentGoogleOAuth2Strategy Read(
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
            return new ConnectionResponseContentGoogleOAuth2Strategy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionResponseContentGoogleOAuth2Strategy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConnectionResponseContentGoogleOAuth2Strategy ReadAsPropertyName(
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
            return new ConnectionResponseContentGoogleOAuth2Strategy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConnectionResponseContentGoogleOAuth2Strategy value,
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
        public const string GoogleOauth2 = "google-oauth2";
    }
}
