using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ConnectionWaadProtocolEnumAzureAd.ConnectionWaadProtocolEnumAzureAdSerializer)
)]
[Serializable]
public readonly record struct ConnectionWaadProtocolEnumAzureAd : IStringEnum
{
    public static readonly ConnectionWaadProtocolEnumAzureAd WsFederation = new(
        Values.WsFederation
    );

    public static readonly ConnectionWaadProtocolEnumAzureAd OpenidConnect = new(
        Values.OpenidConnect
    );

    public ConnectionWaadProtocolEnumAzureAd(string value)
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
    public static ConnectionWaadProtocolEnumAzureAd FromCustom(string value)
    {
        return new ConnectionWaadProtocolEnumAzureAd(value);
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

    public static bool operator ==(ConnectionWaadProtocolEnumAzureAd value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionWaadProtocolEnumAzureAd value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionWaadProtocolEnumAzureAd value) => value.Value;

    public static explicit operator ConnectionWaadProtocolEnumAzureAd(string value) => new(value);

    internal class ConnectionWaadProtocolEnumAzureAdSerializer
        : JsonConverter<ConnectionWaadProtocolEnumAzureAd>
    {
        public override ConnectionWaadProtocolEnumAzureAd Read(
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
            return new ConnectionWaadProtocolEnumAzureAd(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionWaadProtocolEnumAzureAd value,
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
        public const string WsFederation = "ws-federation";

        public const string OpenidConnect = "openid-connect";
    }
}
