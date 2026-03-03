using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowsVaultConnectioSetupTypeOauthCodeEnum>))]
[Serializable]
public readonly record struct FlowsVaultConnectioSetupTypeOauthCodeEnum : IStringEnum
{
    public static readonly FlowsVaultConnectioSetupTypeOauthCodeEnum OauthCode = new(
        Values.OauthCode
    );

    public FlowsVaultConnectioSetupTypeOauthCodeEnum(string value)
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
    public static FlowsVaultConnectioSetupTypeOauthCodeEnum FromCustom(string value)
    {
        return new FlowsVaultConnectioSetupTypeOauthCodeEnum(value);
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
        FlowsVaultConnectioSetupTypeOauthCodeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        FlowsVaultConnectioSetupTypeOauthCodeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(FlowsVaultConnectioSetupTypeOauthCodeEnum value) =>
        value.Value;

    public static explicit operator FlowsVaultConnectioSetupTypeOauthCodeEnum(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string OauthCode = "OAUTH_CODE";
    }
}
