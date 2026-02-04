using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.AttackProtection;

[JsonConverter(typeof(StringEnumSerializer<UpdateBruteForceSettingsRequestContentShieldsItem>))]
[Serializable]
public readonly record struct UpdateBruteForceSettingsRequestContentShieldsItem : IStringEnum
{
    public static readonly UpdateBruteForceSettingsRequestContentShieldsItem Block = new(
        Values.Block
    );

    public static readonly UpdateBruteForceSettingsRequestContentShieldsItem UserNotification = new(
        Values.UserNotification
    );

    public UpdateBruteForceSettingsRequestContentShieldsItem(string value)
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
    public static UpdateBruteForceSettingsRequestContentShieldsItem FromCustom(string value)
    {
        return new UpdateBruteForceSettingsRequestContentShieldsItem(value);
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
        UpdateBruteForceSettingsRequestContentShieldsItem value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        UpdateBruteForceSettingsRequestContentShieldsItem value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        UpdateBruteForceSettingsRequestContentShieldsItem value
    ) => value.Value;

    public static explicit operator UpdateBruteForceSettingsRequestContentShieldsItem(
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
