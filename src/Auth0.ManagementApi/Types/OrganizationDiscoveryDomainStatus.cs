using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<OrganizationDiscoveryDomainStatus>))]
[Serializable]
public readonly record struct OrganizationDiscoveryDomainStatus : IStringEnum
{
    public static readonly OrganizationDiscoveryDomainStatus Pending = new(Values.Pending);

    public static readonly OrganizationDiscoveryDomainStatus Verified = new(Values.Verified);

    public OrganizationDiscoveryDomainStatus(string value)
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
    public static OrganizationDiscoveryDomainStatus FromCustom(string value)
    {
        return new OrganizationDiscoveryDomainStatus(value);
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

    public static bool operator ==(OrganizationDiscoveryDomainStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OrganizationDiscoveryDomainStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OrganizationDiscoveryDomainStatus value) => value.Value;

    public static explicit operator OrganizationDiscoveryDomainStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Pending = "pending";

        public const string Verified = "verified";
    }
}
