using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ConnectionOptionsProtocolEnumTwitter.ConnectionOptionsProtocolEnumTwitterSerializer)
)]
[Serializable]
public readonly record struct ConnectionOptionsProtocolEnumTwitter : IStringEnum
{
    public static readonly ConnectionOptionsProtocolEnumTwitter Oauth1 = new(Values.Oauth1);

    public static readonly ConnectionOptionsProtocolEnumTwitter Oauth2 = new(Values.Oauth2);

    public ConnectionOptionsProtocolEnumTwitter(string value)
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
    public static ConnectionOptionsProtocolEnumTwitter FromCustom(string value)
    {
        return new ConnectionOptionsProtocolEnumTwitter(value);
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

    public static bool operator ==(ConnectionOptionsProtocolEnumTwitter value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionOptionsProtocolEnumTwitter value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionOptionsProtocolEnumTwitter value) =>
        value.Value;

    public static explicit operator ConnectionOptionsProtocolEnumTwitter(string value) =>
        new(value);

    internal class ConnectionOptionsProtocolEnumTwitterSerializer
        : JsonConverter<ConnectionOptionsProtocolEnumTwitter>
    {
        public override ConnectionOptionsProtocolEnumTwitter Read(
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
            return new ConnectionOptionsProtocolEnumTwitter(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionOptionsProtocolEnumTwitter value,
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

        public const string Oauth2 = "oauth2";
    }
}
