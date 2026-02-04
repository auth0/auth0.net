using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<DomainCertificateAuthorityEnum>))]
[Serializable]
public readonly record struct DomainCertificateAuthorityEnum : IStringEnum
{
    public static readonly DomainCertificateAuthorityEnum Letsencrypt = new(Values.Letsencrypt);

    public static readonly DomainCertificateAuthorityEnum Googletrust = new(Values.Googletrust);

    public DomainCertificateAuthorityEnum(string value)
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
    public static DomainCertificateAuthorityEnum FromCustom(string value)
    {
        return new DomainCertificateAuthorityEnum(value);
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

    public static bool operator ==(DomainCertificateAuthorityEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DomainCertificateAuthorityEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DomainCertificateAuthorityEnum value) => value.Value;

    public static explicit operator DomainCertificateAuthorityEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Letsencrypt = "letsencrypt";

        public const string Googletrust = "googletrust";
    }
}
