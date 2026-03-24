using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowActionStripeCreateCustomerAction.FlowActionStripeCreateCustomerActionSerializer)
)]
[Serializable]
public readonly record struct FlowActionStripeCreateCustomerAction : IStringEnum
{
    public static readonly FlowActionStripeCreateCustomerAction CreateCustomer = new(
        Values.CreateCustomer
    );

    public FlowActionStripeCreateCustomerAction(string value)
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
    public static FlowActionStripeCreateCustomerAction FromCustom(string value)
    {
        return new FlowActionStripeCreateCustomerAction(value);
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

    public static bool operator ==(FlowActionStripeCreateCustomerAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionStripeCreateCustomerAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionStripeCreateCustomerAction value) =>
        value.Value;

    public static explicit operator FlowActionStripeCreateCustomerAction(string value) =>
        new(value);

    internal class FlowActionStripeCreateCustomerActionSerializer
        : JsonConverter<FlowActionStripeCreateCustomerAction>
    {
        public override FlowActionStripeCreateCustomerAction Read(
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
            return new FlowActionStripeCreateCustomerAction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionStripeCreateCustomerAction value,
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
        public const string CreateCustomer = "CREATE_CUSTOMER";
    }
}
