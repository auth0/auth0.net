using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<ResourceServerSubjectTypeAuthorizationUserPolicyEnum>))]
[Serializable]
public readonly record struct ResourceServerSubjectTypeAuthorizationUserPolicyEnum : IStringEnum
{
    public static readonly ResourceServerSubjectTypeAuthorizationUserPolicyEnum AllowAll = new(
        Values.AllowAll
    );

    public static readonly ResourceServerSubjectTypeAuthorizationUserPolicyEnum DenyAll = new(
        Values.DenyAll
    );

    public static readonly ResourceServerSubjectTypeAuthorizationUserPolicyEnum RequireClientGrant =
        new(Values.RequireClientGrant);

    public ResourceServerSubjectTypeAuthorizationUserPolicyEnum(string value)
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
    public static ResourceServerSubjectTypeAuthorizationUserPolicyEnum FromCustom(string value)
    {
        return new ResourceServerSubjectTypeAuthorizationUserPolicyEnum(value);
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

    public static bool operator ==(
        ResourceServerSubjectTypeAuthorizationUserPolicyEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ResourceServerSubjectTypeAuthorizationUserPolicyEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ResourceServerSubjectTypeAuthorizationUserPolicyEnum value
    ) => value.Value;

    public static explicit operator ResourceServerSubjectTypeAuthorizationUserPolicyEnum(
        string value
    ) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string AllowAll = "allow_all";

        public const string DenyAll = "deny_all";

        public const string RequireClientGrant = "require_client_grant";
    }
}
