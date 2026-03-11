using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<ResourceServerConsentPolicyEnum>))]
[Serializable]
public readonly record struct ResourceServerConsentPolicyEnum : IStringEnum
{
    public static readonly ResourceServerConsentPolicyEnum TransactionalAuthorizationWithMfa = new(
        Values.TransactionalAuthorizationWithMfa
    );

    public ResourceServerConsentPolicyEnum(string value)
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
    public static ResourceServerConsentPolicyEnum FromCustom(string value)
    {
        return new ResourceServerConsentPolicyEnum(value);
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

    public static bool operator ==(ResourceServerConsentPolicyEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ResourceServerConsentPolicyEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ResourceServerConsentPolicyEnum value) => value.Value;

    public static explicit operator ResourceServerConsentPolicyEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string TransactionalAuthorizationWithMfa =
            "transactional-authorization-with-mfa";
    }
}
