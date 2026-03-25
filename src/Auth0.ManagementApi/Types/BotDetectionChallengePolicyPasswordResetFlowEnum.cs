using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(BotDetectionChallengePolicyPasswordResetFlowEnum.BotDetectionChallengePolicyPasswordResetFlowEnumSerializer)
)]
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

    internal class BotDetectionChallengePolicyPasswordResetFlowEnumSerializer
        : JsonConverter<BotDetectionChallengePolicyPasswordResetFlowEnum>
    {
        public override BotDetectionChallengePolicyPasswordResetFlowEnum Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new BotDetectionChallengePolicyPasswordResetFlowEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BotDetectionChallengePolicyPasswordResetFlowEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BotDetectionChallengePolicyPasswordResetFlowEnum ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new BotDetectionChallengePolicyPasswordResetFlowEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BotDetectionChallengePolicyPasswordResetFlowEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

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
