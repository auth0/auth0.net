using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<BotDetectionChallengePolicyPasswordlessFlowEnum>))]
[Serializable]
public readonly record struct BotDetectionChallengePolicyPasswordlessFlowEnum : IStringEnum
{
    public static readonly BotDetectionChallengePolicyPasswordlessFlowEnum Never = new(
        Values.Never
    );

    public static readonly BotDetectionChallengePolicyPasswordlessFlowEnum WhenRisky = new(
        Values.WhenRisky
    );

    public static readonly BotDetectionChallengePolicyPasswordlessFlowEnum Always = new(
        Values.Always
    );

    public BotDetectionChallengePolicyPasswordlessFlowEnum(string value)
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
    public static BotDetectionChallengePolicyPasswordlessFlowEnum FromCustom(string value)
    {
        return new BotDetectionChallengePolicyPasswordlessFlowEnum(value);
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
        BotDetectionChallengePolicyPasswordlessFlowEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BotDetectionChallengePolicyPasswordlessFlowEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(BotDetectionChallengePolicyPasswordlessFlowEnum value) =>
        value.Value;

    public static explicit operator BotDetectionChallengePolicyPasswordlessFlowEnum(string value) =>
        new(value);

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
