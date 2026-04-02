using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(BotDetectionChallengePolicyPasswordFlowEnum.BotDetectionChallengePolicyPasswordFlowEnumSerializer)
)]
[Serializable]
public readonly record struct BotDetectionChallengePolicyPasswordFlowEnum : IStringEnum
{
    public static readonly BotDetectionChallengePolicyPasswordFlowEnum Never = new(Values.Never);

    public static readonly BotDetectionChallengePolicyPasswordFlowEnum WhenRisky = new(
        Values.WhenRisky
    );

    public static readonly BotDetectionChallengePolicyPasswordFlowEnum Always = new(Values.Always);

    public BotDetectionChallengePolicyPasswordFlowEnum(string value)
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
    public static BotDetectionChallengePolicyPasswordFlowEnum FromCustom(string value)
    {
        return new BotDetectionChallengePolicyPasswordFlowEnum(value);
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
        BotDetectionChallengePolicyPasswordFlowEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BotDetectionChallengePolicyPasswordFlowEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(BotDetectionChallengePolicyPasswordFlowEnum value) =>
        value.Value;

    public static explicit operator BotDetectionChallengePolicyPasswordFlowEnum(string value) =>
        new(value);

    internal class BotDetectionChallengePolicyPasswordFlowEnumSerializer
        : JsonConverter<BotDetectionChallengePolicyPasswordFlowEnum>
    {
        public override BotDetectionChallengePolicyPasswordFlowEnum Read(
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
            return new BotDetectionChallengePolicyPasswordFlowEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BotDetectionChallengePolicyPasswordFlowEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BotDetectionChallengePolicyPasswordFlowEnum ReadAsPropertyName(
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
            return new BotDetectionChallengePolicyPasswordFlowEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BotDetectionChallengePolicyPasswordFlowEnum value,
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
