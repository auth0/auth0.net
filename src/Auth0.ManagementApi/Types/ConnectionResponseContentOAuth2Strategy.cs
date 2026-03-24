using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<ConnectionResponseContentOAuth2Strategy>))]
[Serializable]
public readonly record struct ConnectionResponseContentOAuth2Strategy : IStringEnum
{
    public static readonly ConnectionResponseContentOAuth2Strategy Oauth2 = new(Values.Oauth2);

    public ConnectionResponseContentOAuth2Strategy(string value)
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
    public static ConnectionResponseContentOAuth2Strategy FromCustom(string value)
    {
        return new ConnectionResponseContentOAuth2Strategy(value);
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

    public static bool operator ==(ConnectionResponseContentOAuth2Strategy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionResponseContentOAuth2Strategy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionResponseContentOAuth2Strategy value) =>
        value.Value;

    public static explicit operator ConnectionResponseContentOAuth2Strategy(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Oauth2 = "oauth2";
    }
}
