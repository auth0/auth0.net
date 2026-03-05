using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowsVaultConnectionAppIdZapierEnum>))]
[Serializable]
public readonly record struct FlowsVaultConnectionAppIdZapierEnum : IStringEnum
{
    public static readonly FlowsVaultConnectionAppIdZapierEnum Zapier = new(Values.Zapier);

    public FlowsVaultConnectionAppIdZapierEnum(string value)
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
    public static FlowsVaultConnectionAppIdZapierEnum FromCustom(string value)
    {
        return new FlowsVaultConnectionAppIdZapierEnum(value);
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

    public static bool operator ==(FlowsVaultConnectionAppIdZapierEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowsVaultConnectionAppIdZapierEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowsVaultConnectionAppIdZapierEnum value) =>
        value.Value;

    public static explicit operator FlowsVaultConnectionAppIdZapierEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Zapier = "ZAPIER";
    }
}
