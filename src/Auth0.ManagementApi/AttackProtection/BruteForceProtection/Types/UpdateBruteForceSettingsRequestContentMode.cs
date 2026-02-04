using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.AttackProtection;

[JsonConverter(typeof(StringEnumSerializer<UpdateBruteForceSettingsRequestContentMode>))]
[Serializable]
public readonly record struct UpdateBruteForceSettingsRequestContentMode : IStringEnum
{
    public static readonly UpdateBruteForceSettingsRequestContentMode CountPerIdentifierAndIp = new(
        Values.CountPerIdentifierAndIp
    );

    public static readonly UpdateBruteForceSettingsRequestContentMode CountPerIdentifier = new(
        Values.CountPerIdentifier
    );

    public UpdateBruteForceSettingsRequestContentMode(string value)
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
    public static UpdateBruteForceSettingsRequestContentMode FromCustom(string value)
    {
        return new UpdateBruteForceSettingsRequestContentMode(value);
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
        UpdateBruteForceSettingsRequestContentMode value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        UpdateBruteForceSettingsRequestContentMode value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(UpdateBruteForceSettingsRequestContentMode value) =>
        value.Value;

    public static explicit operator UpdateBruteForceSettingsRequestContentMode(string value) =>
        new(value);

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
