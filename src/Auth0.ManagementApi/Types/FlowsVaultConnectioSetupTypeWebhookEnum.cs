using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowsVaultConnectioSetupTypeWebhookEnum>))]
[Serializable]
public readonly record struct FlowsVaultConnectioSetupTypeWebhookEnum : IStringEnum
{
    public static readonly FlowsVaultConnectioSetupTypeWebhookEnum Webhook = new(Values.Webhook);

    public FlowsVaultConnectioSetupTypeWebhookEnum(string value)
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
    public static FlowsVaultConnectioSetupTypeWebhookEnum FromCustom(string value)
    {
        return new FlowsVaultConnectioSetupTypeWebhookEnum(value);
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

    public static bool operator ==(FlowsVaultConnectioSetupTypeWebhookEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowsVaultConnectioSetupTypeWebhookEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowsVaultConnectioSetupTypeWebhookEnum value) =>
        value.Value;

    public static explicit operator FlowsVaultConnectioSetupTypeWebhookEnum(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Webhook = "WEBHOOK";
    }
}
