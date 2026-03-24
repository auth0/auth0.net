using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowActionStripeCreateCustomerType.FlowActionStripeCreateCustomerTypeSerializer)
)]
[Serializable]
public readonly record struct FlowActionStripeCreateCustomerType : IStringEnum
{
    public static readonly FlowActionStripeCreateCustomerType Stripe = new(Values.Stripe);

    public FlowActionStripeCreateCustomerType(string value)
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
    public static FlowActionStripeCreateCustomerType FromCustom(string value)
    {
        return new FlowActionStripeCreateCustomerType(value);
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

    public static bool operator ==(FlowActionStripeCreateCustomerType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionStripeCreateCustomerType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionStripeCreateCustomerType value) => value.Value;

    public static explicit operator FlowActionStripeCreateCustomerType(string value) => new(value);

    internal class FlowActionStripeCreateCustomerTypeSerializer
        : JsonConverter<FlowActionStripeCreateCustomerType>
    {
        public override FlowActionStripeCreateCustomerType Read(
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
            return new FlowActionStripeCreateCustomerType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionStripeCreateCustomerType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
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
