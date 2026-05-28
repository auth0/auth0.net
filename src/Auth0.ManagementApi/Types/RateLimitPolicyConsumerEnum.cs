using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(RateLimitPolicyConsumerEnum.RateLimitPolicyConsumerEnumSerializer))]
[Serializable]
public readonly record struct RateLimitPolicyConsumerEnum : IStringEnum
{
    public static readonly RateLimitPolicyConsumerEnum Client = new(Values.Client);

    public RateLimitPolicyConsumerEnum(string value)
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
    public static RateLimitPolicyConsumerEnum FromCustom(string value)
    {
        return new RateLimitPolicyConsumerEnum(value);
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

    public static bool operator ==(RateLimitPolicyConsumerEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(RateLimitPolicyConsumerEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(RateLimitPolicyConsumerEnum value) => value.Value;

    public static explicit operator RateLimitPolicyConsumerEnum(string value) => new(value);

    internal class RateLimitPolicyConsumerEnumSerializer
        : JsonConverter<RateLimitPolicyConsumerEnum>
    {
        public override RateLimitPolicyConsumerEnum Read(
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
            return new RateLimitPolicyConsumerEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RateLimitPolicyConsumerEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RateLimitPolicyConsumerEnum ReadAsPropertyName(
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
            return new RateLimitPolicyConsumerEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RateLimitPolicyConsumerEnum value,
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
        public const string Client = "client";
    }
}
