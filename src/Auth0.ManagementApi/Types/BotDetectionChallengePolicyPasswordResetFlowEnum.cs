using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<BotDetectionChallengePolicyPasswordResetFlowEnum>))]
[Serializable]
public readonly record struct BotDetectionChallengePolicyPasswordResetFlowEnum : IStringEnum
{
    public static readonly BotDetectionChallengePolicyPasswordResetFlowEnum Never = new(
        Values.Never
    );

    public static readonly BotDetectionChallengePolicyPasswordResetFlowEnum WhenRisky = new(
        Values.WhenRisky
    );

    public static readonly BotDetectionChallengePolicyPasswordResetFlowEnum Always = new(
        Values.Always
    );

    public BotDetectionChallengePolicyPasswordResetFlowEnum(string value)
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
    public static BotDetectionChallengePolicyPasswordResetFlowEnum FromCustom(string value)
    {
        return new BotDetectionChallengePolicyPasswordResetFlowEnum(value);
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
        BotDetectionChallengePolicyPasswordResetFlowEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BotDetectionChallengePolicyPasswordResetFlowEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        BotDetectionChallengePolicyPasswordResetFlowEnum value
    ) => value.Value;

    public static explicit operator BotDetectionChallengePolicyPasswordResetFlowEnum(
        string value
    ) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Never = "never";

        public const string WhenRisky = "when_risky";

        public const string Always = "always";
    }
}
