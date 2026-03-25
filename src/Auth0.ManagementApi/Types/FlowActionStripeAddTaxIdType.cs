using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionStripeAddTaxIdType.FlowActionStripeAddTaxIdTypeSerializer))]
[Serializable]
public readonly record struct FlowActionStripeAddTaxIdType : IStringEnum
{
    public static readonly FlowActionStripeAddTaxIdType Stripe = new(Values.Stripe);

    public FlowActionStripeAddTaxIdType(string value)
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
    public static FlowActionStripeAddTaxIdType FromCustom(string value)
    {
        return new FlowActionStripeAddTaxIdType(value);
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

    public static bool operator ==(FlowActionStripeAddTaxIdType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionStripeAddTaxIdType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionStripeAddTaxIdType value) => value.Value;

    public static explicit operator FlowActionStripeAddTaxIdType(string value) => new(value);

    internal class FlowActionStripeAddTaxIdTypeSerializer
        : JsonConverter<FlowActionStripeAddTaxIdType>
    {
        public override FlowActionStripeAddTaxIdType Read(
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
            return new FlowActionStripeAddTaxIdType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionStripeAddTaxIdType value,
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
