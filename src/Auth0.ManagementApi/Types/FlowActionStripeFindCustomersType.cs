using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowActionStripeFindCustomersType>))]
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

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Stripe = "STRIPE";
    }
}
