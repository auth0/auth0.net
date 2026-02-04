using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<CustomDomainProvisioningTypeEnum>))]
[Serializable]
public readonly record struct CustomDomainProvisioningTypeEnum : IStringEnum
{
    public static readonly CustomDomainProvisioningTypeEnum Auth0ManagedCerts = new(
        Values.Auth0ManagedCerts
    );

    public static readonly CustomDomainProvisioningTypeEnum SelfManagedCerts = new(
        Values.SelfManagedCerts
    );

    public CustomDomainProvisioningTypeEnum(string value)
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
    public static CustomDomainProvisioningTypeEnum FromCustom(string value)
    {
        return new CustomDomainProvisioningTypeEnum(value);
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

    public static bool operator ==(CustomDomainProvisioningTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CustomDomainProvisioningTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CustomDomainProvisioningTypeEnum value) => value.Value;

    public static explicit operator CustomDomainProvisioningTypeEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Auth0ManagedCerts = "auth0_managed_certs";

        public const string SelfManagedCerts = "self_managed_certs";
    }
}
