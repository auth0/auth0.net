using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowActionStripeUpdateCustomerAction>))]
[Serializable]
public readonly record struct FlowActionStripeUpdateCustomerAction : IStringEnum
{
    public static readonly FlowActionStripeUpdateCustomerAction UpdateCustomer = new(
        Values.UpdateCustomer
    );

    public FlowActionStripeUpdateCustomerAction(string value)
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
    public static FlowActionStripeUpdateCustomerAction FromCustom(string value)
    {
        return new FlowActionStripeUpdateCustomerAction(value);
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

    public static bool operator ==(FlowActionStripeUpdateCustomerAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionStripeUpdateCustomerAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionStripeUpdateCustomerAction value) =>
        value.Value;

    public static explicit operator FlowActionStripeUpdateCustomerAction(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string UpdateCustomer = "UPDATE_CUSTOMER";
    }
}
