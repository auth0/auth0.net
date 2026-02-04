using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<UpdateBruteForceSettingsResponseContentMode>))]
[Serializable]
public readonly record struct UpdateBruteForceSettingsResponseContentMode : IStringEnum
{
    public static readonly UpdateBruteForceSettingsResponseContentMode CountPerIdentifierAndIp =
        new(Values.CountPerIdentifierAndIp);

    public static readonly UpdateBruteForceSettingsResponseContentMode CountPerIdentifier = new(
        Values.CountPerIdentifier
    );

    public UpdateBruteForceSettingsResponseContentMode(string value)
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
    public static UpdateBruteForceSettingsResponseContentMode FromCustom(string value)
    {
        return new UpdateBruteForceSettingsResponseContentMode(value);
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
        UpdateBruteForceSettingsResponseContentMode value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        UpdateBruteForceSettingsResponseContentMode value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(UpdateBruteForceSettingsResponseContentMode value) =>
        value.Value;

    public static explicit operator UpdateBruteForceSettingsResponseContentMode(string value) =>
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
