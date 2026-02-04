using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<ClientOrganizationDiscoveryEnum>))]
[Serializable]
public readonly record struct ClientOrganizationDiscoveryEnum : IStringEnum
{
    public static readonly ClientOrganizationDiscoveryEnum Email = new(Values.Email);

    public static readonly ClientOrganizationDiscoveryEnum OrganizationName = new(
        Values.OrganizationName
    );

    public ClientOrganizationDiscoveryEnum(string value)
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
    public static ClientOrganizationDiscoveryEnum FromCustom(string value)
    {
        return new ClientOrganizationDiscoveryEnum(value);
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

    public static bool operator ==(ClientOrganizationDiscoveryEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ClientOrganizationDiscoveryEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ClientOrganizationDiscoveryEnum value) => value.Value;

    public static explicit operator ClientOrganizationDiscoveryEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Email = "email";

        public const string OrganizationName = "organization_name";
    }
}
