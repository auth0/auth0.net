using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<ConnectionTokenEndpointAuthMethodEnum>))]
[Serializable]
public readonly record struct ConnectionTokenEndpointAuthMethodEnum : IStringEnum
{
    public static readonly ConnectionTokenEndpointAuthMethodEnum ClientSecretPost = new(
        Values.ClientSecretPost
    );

    public static readonly ConnectionTokenEndpointAuthMethodEnum PrivateKeyJwt = new(
        Values.PrivateKeyJwt
    );

    public ConnectionTokenEndpointAuthMethodEnum(string value)
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
    public static ConnectionTokenEndpointAuthMethodEnum FromCustom(string value)
    {
        return new ConnectionTokenEndpointAuthMethodEnum(value);
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

    public static bool operator ==(ConnectionTokenEndpointAuthMethodEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionTokenEndpointAuthMethodEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionTokenEndpointAuthMethodEnum value) =>
        value.Value;

    public static explicit operator ConnectionTokenEndpointAuthMethodEnum(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string ClientSecretPost = "client_secret_post";

        public const string PrivateKeyJwt = "private_key_jwt";
    }
}
