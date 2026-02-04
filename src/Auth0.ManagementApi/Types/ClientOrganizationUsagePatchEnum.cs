using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<ClientOrganizationUsagePatchEnum>))]
[Serializable]
public readonly record struct ClientOrganizationUsagePatchEnum : IStringEnum
{
    public static readonly ClientOrganizationUsagePatchEnum Deny = new(Values.Deny);

    public static readonly ClientOrganizationUsagePatchEnum Allow = new(Values.Allow);

    public static readonly ClientOrganizationUsagePatchEnum Require = new(Values.Require);

    public ClientOrganizationUsagePatchEnum(string value)
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
    public static ClientOrganizationUsagePatchEnum FromCustom(string value)
    {
        return new ClientOrganizationUsagePatchEnum(value);
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

    public static bool operator ==(ClientOrganizationUsagePatchEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ClientOrganizationUsagePatchEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ClientOrganizationUsagePatchEnum value) => value.Value;

    public static explicit operator ClientOrganizationUsagePatchEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Deny = "deny";

        public const string Allow = "allow";

        public const string Require = "require";
    }
}
