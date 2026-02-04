using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<GetBruteForceSettingsResponseContentMode>))]
[Serializable]
public readonly record struct GetBruteForceSettingsResponseContentMode : IStringEnum
{
    public static readonly GetBruteForceSettingsResponseContentMode CountPerIdentifierAndIp = new(
        Values.CountPerIdentifierAndIp
    );

    public static readonly GetBruteForceSettingsResponseContentMode CountPerIdentifier = new(
        Values.CountPerIdentifier
    );

    public GetBruteForceSettingsResponseContentMode(string value)
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
    public static GetBruteForceSettingsResponseContentMode FromCustom(string value)
    {
        return new GetBruteForceSettingsResponseContentMode(value);
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
        GetBruteForceSettingsResponseContentMode value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        GetBruteForceSettingsResponseContentMode value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(GetBruteForceSettingsResponseContentMode value) =>
        value.Value;

    public static explicit operator GetBruteForceSettingsResponseContentMode(string value) =>
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
