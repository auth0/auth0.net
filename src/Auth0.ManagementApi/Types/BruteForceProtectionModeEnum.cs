using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<BruteForceProtectionModeEnum>))]
[Serializable]
public readonly record struct BruteForceProtectionModeEnum : IStringEnum
{
    public static readonly BruteForceProtectionModeEnum CountPerIdentifierAndIp = new(
        Values.CountPerIdentifierAndIp
    );

    public static readonly BruteForceProtectionModeEnum CountPerIdentifier = new(
        Values.CountPerIdentifier
    );

    public BruteForceProtectionModeEnum(string value)
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
    public static BruteForceProtectionModeEnum FromCustom(string value)
    {
        return new BruteForceProtectionModeEnum(value);
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

    public static bool operator ==(BruteForceProtectionModeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BruteForceProtectionModeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BruteForceProtectionModeEnum value) => value.Value;

    public static explicit operator BruteForceProtectionModeEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string CountPerIdentifierAndIp = "count_per_identifier_and_ip";

        public const string CountPerIdentifier = "count_per_identifier";
    }
}
