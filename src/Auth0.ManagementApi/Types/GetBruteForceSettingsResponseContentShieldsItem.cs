using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<GetBruteForceSettingsResponseContentShieldsItem>))]
[Serializable]
public readonly record struct GetBruteForceSettingsResponseContentShieldsItem : IStringEnum
{
    public static readonly GetBruteForceSettingsResponseContentShieldsItem Block = new(
        Values.Block
    );

    public static readonly GetBruteForceSettingsResponseContentShieldsItem UserNotification = new(
        Values.UserNotification
    );

    public GetBruteForceSettingsResponseContentShieldsItem(string value)
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
    public static GetBruteForceSettingsResponseContentShieldsItem FromCustom(string value)
    {
        return new GetBruteForceSettingsResponseContentShieldsItem(value);
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
        GetBruteForceSettingsResponseContentShieldsItem value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        GetBruteForceSettingsResponseContentShieldsItem value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(GetBruteForceSettingsResponseContentShieldsItem value) =>
        value.Value;

    public static explicit operator GetBruteForceSettingsResponseContentShieldsItem(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Block = "block";

        public const string UserNotification = "user_notification";
    }
}
