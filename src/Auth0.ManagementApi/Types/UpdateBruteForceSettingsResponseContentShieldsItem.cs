using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<UpdateBruteForceSettingsResponseContentShieldsItem>))]
[Serializable]
public readonly record struct UpdateBruteForceSettingsResponseContentShieldsItem : IStringEnum
{
    public static readonly UpdateBruteForceSettingsResponseContentShieldsItem Block = new(
        Values.Block
    );

    public static readonly UpdateBruteForceSettingsResponseContentShieldsItem UserNotification =
        new(Values.UserNotification);

    public UpdateBruteForceSettingsResponseContentShieldsItem(string value)
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
    public static UpdateBruteForceSettingsResponseContentShieldsItem FromCustom(string value)
    {
        return new UpdateBruteForceSettingsResponseContentShieldsItem(value);
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
        UpdateBruteForceSettingsResponseContentShieldsItem value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        UpdateBruteForceSettingsResponseContentShieldsItem value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        UpdateBruteForceSettingsResponseContentShieldsItem value
    ) => value.Value;

    public static explicit operator UpdateBruteForceSettingsResponseContentShieldsItem(
        string value
    ) => new(value);

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
