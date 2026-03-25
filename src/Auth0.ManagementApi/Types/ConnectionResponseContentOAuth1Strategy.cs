using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ConnectionResponseContentOAuth1Strategy.ConnectionResponseContentOAuth1StrategySerializer)
)]
[Serializable]
public readonly record struct ConnectionResponseContentOAuth1Strategy : IStringEnum
{
    public static readonly ConnectionResponseContentOAuth1Strategy Oauth1 = new(Values.Oauth1);

    public ConnectionResponseContentOAuth1Strategy(string value)
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
    public static ConnectionResponseContentOAuth1Strategy FromCustom(string value)
    {
        return new ConnectionResponseContentOAuth1Strategy(value);
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

    public static bool operator ==(ConnectionResponseContentOAuth1Strategy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionResponseContentOAuth1Strategy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionResponseContentOAuth1Strategy value) =>
        value.Value;

    public static explicit operator ConnectionResponseContentOAuth1Strategy(string value) =>
        new(value);

    internal class ConnectionResponseContentOAuth1StrategySerializer
        : JsonConverter<ConnectionResponseContentOAuth1Strategy>
    {
        public override ConnectionResponseContentOAuth1Strategy Read(
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
            return new ConnectionResponseContentOAuth1Strategy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionResponseContentOAuth1Strategy value,
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
        public const string Oauth1 = "oauth1";
    }
}
