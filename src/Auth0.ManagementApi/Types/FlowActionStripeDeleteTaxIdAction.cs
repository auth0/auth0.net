using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowActionStripeDeleteTaxIdAction>))]
[Serializable]
public readonly record struct FlowActionStripeDeleteTaxIdAction : IStringEnum
{
    public static readonly FlowActionStripeDeleteTaxIdAction DeleteTaxId = new(Values.DeleteTaxId);

    public FlowActionStripeDeleteTaxIdAction(string value)
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
    public static FlowActionStripeDeleteTaxIdAction FromCustom(string value)
    {
        return new FlowActionStripeDeleteTaxIdAction(value);
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

    public static bool operator ==(FlowActionStripeDeleteTaxIdAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionStripeDeleteTaxIdAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionStripeDeleteTaxIdAction value) => value.Value;

    public static explicit operator FlowActionStripeDeleteTaxIdAction(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string DeleteTaxId = "DELETE_TAX_ID";
    }
}
