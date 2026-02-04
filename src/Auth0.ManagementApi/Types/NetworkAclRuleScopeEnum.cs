using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<NetworkAclRuleScopeEnum>))]
[Serializable]
public readonly record struct NetworkAclRuleScopeEnum : IStringEnum
{
    public static readonly NetworkAclRuleScopeEnum Management = new(Values.Management);

    public static readonly NetworkAclRuleScopeEnum Authentication = new(Values.Authentication);

    public static readonly NetworkAclRuleScopeEnum Tenant = new(Values.Tenant);

    public static readonly NetworkAclRuleScopeEnum DynamicClientRegistration = new(
        Values.DynamicClientRegistration
    );

    public NetworkAclRuleScopeEnum(string value)
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
    public static NetworkAclRuleScopeEnum FromCustom(string value)
    {
        return new NetworkAclRuleScopeEnum(value);
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

    public static bool operator ==(NetworkAclRuleScopeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(NetworkAclRuleScopeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(NetworkAclRuleScopeEnum value) => value.Value;

    public static explicit operator NetworkAclRuleScopeEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Management = "management";

        public const string Authentication = "authentication";

        public const string Tenant = "tenant";

        public const string DynamicClientRegistration = "dynamic_client_registration";
    }
}
