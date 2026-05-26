using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(RateLimitPolicyConfigurationOneAction.RateLimitPolicyConfigurationOneActionSerializer)
)]
[Serializable]
public readonly record struct RateLimitPolicyConfigurationOneAction : IStringEnum
{
    public static readonly RateLimitPolicyConfigurationOneAction Block = new(Values.Block);

    public static readonly RateLimitPolicyConfigurationOneAction Log = new(Values.Log);

    public RateLimitPolicyConfigurationOneAction(string value)
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
    public static RateLimitPolicyConfigurationOneAction FromCustom(string value)
    {
        return new RateLimitPolicyConfigurationOneAction(value);
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

    public static bool operator ==(RateLimitPolicyConfigurationOneAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(RateLimitPolicyConfigurationOneAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(RateLimitPolicyConfigurationOneAction value) =>
        value.Value;

    public static explicit operator RateLimitPolicyConfigurationOneAction(string value) =>
        new(value);

    internal class RateLimitPolicyConfigurationOneActionSerializer
        : JsonConverter<RateLimitPolicyConfigurationOneAction>
    {
        public override RateLimitPolicyConfigurationOneAction Read(
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
            return new RateLimitPolicyConfigurationOneAction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RateLimitPolicyConfigurationOneAction value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RateLimitPolicyConfigurationOneAction ReadAsPropertyName(
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
            return new RateLimitPolicyConfigurationOneAction(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RateLimitPolicyConfigurationOneAction value,
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
        public const string Block = "block";

        public const string Log = "log";
    }
}
