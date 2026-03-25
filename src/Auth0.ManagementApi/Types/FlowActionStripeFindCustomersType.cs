using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowActionStripeFindCustomersType.FlowActionStripeFindCustomersTypeSerializer)
)]
[Serializable]
public readonly record struct FlowActionStripeFindCustomersType : IStringEnum
{
    public static readonly FlowActionStripeFindCustomersType Stripe = new(Values.Stripe);

    public FlowActionStripeFindCustomersType(string value)
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
    public static FlowActionStripeFindCustomersType FromCustom(string value)
    {
        return new FlowActionStripeFindCustomersType(value);
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

    public static bool operator ==(FlowActionStripeFindCustomersType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionStripeFindCustomersType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionStripeFindCustomersType value) => value.Value;

    public static explicit operator FlowActionStripeFindCustomersType(string value) => new(value);

    internal class FlowActionStripeFindCustomersTypeSerializer
        : JsonConverter<FlowActionStripeFindCustomersType>
    {
        public override FlowActionStripeFindCustomersType Read(
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
            return new FlowActionStripeFindCustomersType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionStripeFindCustomersType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowActionStripeFindCustomersType ReadAsPropertyName(
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
            return new FlowActionStripeFindCustomersType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionStripeFindCustomersType value,
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
        public const string Stripe = "STRIPE";
    }
}
