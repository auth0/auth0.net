using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowsVaultConnectionSetupTypeBasicAuthEnum>))]
[Serializable]
public readonly record struct FlowsVaultConnectionSetupTypeBasicAuthEnum : IStringEnum
{
    public static readonly FlowsVaultConnectionSetupTypeBasicAuthEnum BasicAuth = new(
        Values.BasicAuth
    );

    public FlowsVaultConnectionSetupTypeBasicAuthEnum(string value)
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
    public static FlowsVaultConnectionSetupTypeBasicAuthEnum FromCustom(string value)
    {
        return new FlowsVaultConnectionSetupTypeBasicAuthEnum(value);
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
        FlowsVaultConnectionSetupTypeBasicAuthEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        FlowsVaultConnectionSetupTypeBasicAuthEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(FlowsVaultConnectionSetupTypeBasicAuthEnum value) =>
        value.Value;

    public static explicit operator FlowsVaultConnectionSetupTypeBasicAuthEnum(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string BasicAuth = "BASIC_AUTH";
    }
}
