using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<ConnectionSignatureAlgorithmEnumSaml>))]
[Serializable]
public readonly record struct ConnectionSignatureAlgorithmEnumSaml : IStringEnum
{
    public static readonly ConnectionSignatureAlgorithmEnumSaml RsaSha1 = new(Values.RsaSha1);

    public static readonly ConnectionSignatureAlgorithmEnumSaml RsaSha256 = new(Values.RsaSha256);

    public ConnectionSignatureAlgorithmEnumSaml(string value)
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
    public static ConnectionSignatureAlgorithmEnumSaml FromCustom(string value)
    {
        return new ConnectionSignatureAlgorithmEnumSaml(value);
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

    public static bool operator ==(ConnectionSignatureAlgorithmEnumSaml value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionSignatureAlgorithmEnumSaml value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionSignatureAlgorithmEnumSaml value) =>
        value.Value;

    public static explicit operator ConnectionSignatureAlgorithmEnumSaml(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string RsaSha1 = "rsa-sha1";

        public const string RsaSha256 = "rsa-sha256";
    }
}
