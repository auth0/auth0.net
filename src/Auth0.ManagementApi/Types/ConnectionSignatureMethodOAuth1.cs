using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<ConnectionSignatureMethodOAuth1>))]
[Serializable]
public readonly record struct ConnectionSignatureMethodOAuth1 : IStringEnum
{
    public static readonly ConnectionSignatureMethodOAuth1 RsaSha1 = new(Values.RsaSha1);

    public ConnectionSignatureMethodOAuth1(string value)
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
    public static ConnectionSignatureMethodOAuth1 FromCustom(string value)
    {
        return new ConnectionSignatureMethodOAuth1(value);
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

    public static bool operator ==(ConnectionSignatureMethodOAuth1 value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionSignatureMethodOAuth1 value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionSignatureMethodOAuth1 value) => value.Value;

    public static explicit operator ConnectionSignatureMethodOAuth1(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string RsaSha1 = "RSA-SHA1";
    }
}
