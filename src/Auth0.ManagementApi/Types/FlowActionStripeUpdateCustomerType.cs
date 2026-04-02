using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowActionStripeUpdateCustomerType.FlowActionStripeUpdateCustomerTypeSerializer)
)]
[Serializable]
public readonly record struct FlowActionStripeUpdateCustomerType : IStringEnum
{
    public static readonly FlowActionStripeUpdateCustomerType Stripe = new(Values.Stripe);

    public FlowActionStripeUpdateCustomerType(string value)
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
    public static FlowActionStripeUpdateCustomerType FromCustom(string value)
    {
        return new FlowActionStripeUpdateCustomerType(value);
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

    public static bool operator ==(FlowActionStripeUpdateCustomerType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionStripeUpdateCustomerType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionStripeUpdateCustomerType value) => value.Value;

    public static explicit operator FlowActionStripeUpdateCustomerType(string value) => new(value);

    internal class FlowActionStripeUpdateCustomerTypeSerializer
        : JsonConverter<FlowActionStripeUpdateCustomerType>
    {
        public override FlowActionStripeUpdateCustomerType Read(
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
            return new FlowActionStripeUpdateCustomerType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionStripeUpdateCustomerType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowActionStripeUpdateCustomerType ReadAsPropertyName(
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
            return new FlowActionStripeUpdateCustomerType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionStripeUpdateCustomerType value,
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
