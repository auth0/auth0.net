using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowsVaultConnectioSetupTypeTokenEnum>))]
[Serializable]
public readonly record struct FlowsVaultConnectioSetupTypeTokenEnum : IStringEnum
{
    public static readonly FlowsVaultConnectioSetupTypeTokenEnum Token = new(Values.Token);

    public FlowsVaultConnectioSetupTypeTokenEnum(string value)
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
    public static FlowsVaultConnectioSetupTypeTokenEnum FromCustom(string value)
    {
        return new FlowsVaultConnectioSetupTypeTokenEnum(value);
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

    public static bool operator ==(FlowsVaultConnectioSetupTypeTokenEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowsVaultConnectioSetupTypeTokenEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowsVaultConnectioSetupTypeTokenEnum value) =>
        value.Value;

    public static explicit operator FlowsVaultConnectioSetupTypeTokenEnum(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Token = "TOKEN";
    }
}
