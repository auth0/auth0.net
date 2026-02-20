using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<SelfServiceProfileAllowedStrategyEnum>))]
[Serializable]
public readonly record struct SelfServiceProfileAllowedStrategyEnum : IStringEnum
{
    public static readonly SelfServiceProfileAllowedStrategyEnum Oidc = new(Values.Oidc);

    public static readonly SelfServiceProfileAllowedStrategyEnum Samlp = new(Values.Samlp);

    public static readonly SelfServiceProfileAllowedStrategyEnum Waad = new(Values.Waad);

    public static readonly SelfServiceProfileAllowedStrategyEnum GoogleApps = new(
        Values.GoogleApps
    );

    public static readonly SelfServiceProfileAllowedStrategyEnum Adfs = new(Values.Adfs);

    public static readonly SelfServiceProfileAllowedStrategyEnum Okta = new(Values.Okta);

    public static readonly SelfServiceProfileAllowedStrategyEnum Auth0Samlp = new(
        Values.Auth0Samlp
    );

    public static readonly SelfServiceProfileAllowedStrategyEnum OktaSamlp = new(Values.OktaSamlp);

    public static readonly SelfServiceProfileAllowedStrategyEnum KeycloakSamlp = new(
        Values.KeycloakSamlp
    );

    public static readonly SelfServiceProfileAllowedStrategyEnum Pingfederate = new(
        Values.Pingfederate
    );

    public SelfServiceProfileAllowedStrategyEnum(string value)
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
    public static SelfServiceProfileAllowedStrategyEnum FromCustom(string value)
    {
        return new SelfServiceProfileAllowedStrategyEnum(value);
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

    public static bool operator ==(SelfServiceProfileAllowedStrategyEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SelfServiceProfileAllowedStrategyEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SelfServiceProfileAllowedStrategyEnum value) =>
        value.Value;

    public static explicit operator SelfServiceProfileAllowedStrategyEnum(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Oidc = "oidc";

        public const string Samlp = "samlp";

        public const string Waad = "waad";

        public const string GoogleApps = "google-apps";

        public const string Adfs = "adfs";

        public const string Okta = "okta";

        public const string Auth0Samlp = "auth0-samlp";

        public const string OktaSamlp = "okta-samlp";

        public const string KeycloakSamlp = "keycloak-samlp";

        public const string Pingfederate = "pingfederate";
    }
}
