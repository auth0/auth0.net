using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(StringEnumSerializer<FlowsVaultConnectionSetupTypeOauthClientCredentialsEnum>)
)]
[Serializable]
public readonly record struct FlowsVaultConnectionSetupTypeOauthClientCredentialsEnum : IStringEnum
{
    public static readonly FlowsVaultConnectionSetupTypeOauthClientCredentialsEnum OauthClientCredentials =
        new(Values.OauthClientCredentials);

    public FlowsVaultConnectionSetupTypeOauthClientCredentialsEnum(string value)
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
    public static FlowsVaultConnectionSetupTypeOauthClientCredentialsEnum FromCustom(string value)
    {
        return new FlowsVaultConnectionSetupTypeOauthClientCredentialsEnum(value);
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
        FlowsVaultConnectionSetupTypeOauthClientCredentialsEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        FlowsVaultConnectionSetupTypeOauthClientCredentialsEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        FlowsVaultConnectionSetupTypeOauthClientCredentialsEnum value
    ) => value.Value;

    public static explicit operator FlowsVaultConnectionSetupTypeOauthClientCredentialsEnum(
        string value
    ) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string OauthClientCredentials = "OAUTH_CLIENT_CREDENTIALS";
    }
}
