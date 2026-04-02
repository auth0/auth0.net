using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionStripeDeleteTaxIdType.FlowActionStripeDeleteTaxIdTypeSerializer))]
[Serializable]
public readonly record struct FlowActionStripeDeleteTaxIdType : IStringEnum
{
    public static readonly FlowActionStripeDeleteTaxIdType Stripe = new(Values.Stripe);

    public FlowActionStripeDeleteTaxIdType(string value)
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
    public static FlowActionStripeDeleteTaxIdType FromCustom(string value)
    {
        return new FlowActionStripeDeleteTaxIdType(value);
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

    public static bool operator ==(FlowActionStripeDeleteTaxIdType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionStripeDeleteTaxIdType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionStripeDeleteTaxIdType value) => value.Value;

    public static explicit operator FlowActionStripeDeleteTaxIdType(string value) => new(value);

    internal class FlowActionStripeDeleteTaxIdTypeSerializer
        : JsonConverter<FlowActionStripeDeleteTaxIdType>
    {
        public override FlowActionStripeDeleteTaxIdType Read(
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
            return new FlowActionStripeDeleteTaxIdType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionStripeDeleteTaxIdType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowActionStripeDeleteTaxIdType ReadAsPropertyName(
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
            return new FlowActionStripeDeleteTaxIdType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionStripeDeleteTaxIdType value,
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
