using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowsVaultConnectionHttpApiKeySetupInEnum>))]
[Serializable]
public readonly record struct FlowsVaultConnectionHttpApiKeySetupInEnum : IStringEnum
{
    public static readonly FlowsVaultConnectionHttpApiKeySetupInEnum Header = new(Values.Header);

    public static readonly FlowsVaultConnectionHttpApiKeySetupInEnum Query = new(Values.Query);

    public FlowsVaultConnectionHttpApiKeySetupInEnum(string value)
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
    public static FlowsVaultConnectionHttpApiKeySetupInEnum FromCustom(string value)
    {
        return new FlowsVaultConnectionHttpApiKeySetupInEnum(value);
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
        FlowsVaultConnectionHttpApiKeySetupInEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        FlowsVaultConnectionHttpApiKeySetupInEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(FlowsVaultConnectionHttpApiKeySetupInEnum value) =>
        value.Value;

    public static explicit operator FlowsVaultConnectionHttpApiKeySetupInEnum(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Header = "HEADER";

        public const string Query = "QUERY";
    }
}
