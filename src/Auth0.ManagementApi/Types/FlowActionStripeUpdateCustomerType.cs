using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowActionStripeUpdateCustomerType>))]
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

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Stripe = "STRIPE";
    }
}
