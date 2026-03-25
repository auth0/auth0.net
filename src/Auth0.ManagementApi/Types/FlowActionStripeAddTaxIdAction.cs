using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionStripeAddTaxIdAction.FlowActionStripeAddTaxIdActionSerializer))]
[Serializable]
public readonly record struct FlowActionStripeAddTaxIdAction : IStringEnum
{
    public static readonly FlowActionStripeAddTaxIdAction AddTaxId = new(Values.AddTaxId);

    public FlowActionStripeAddTaxIdAction(string value)
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
    public static FlowActionStripeAddTaxIdAction FromCustom(string value)
    {
        return new FlowActionStripeAddTaxIdAction(value);
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

    public static bool operator ==(FlowActionStripeAddTaxIdAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionStripeAddTaxIdAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionStripeAddTaxIdAction value) => value.Value;

    public static explicit operator FlowActionStripeAddTaxIdAction(string value) => new(value);

    internal class FlowActionStripeAddTaxIdActionSerializer
        : JsonConverter<FlowActionStripeAddTaxIdAction>
    {
        public override FlowActionStripeAddTaxIdAction Read(
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
            return new FlowActionStripeAddTaxIdAction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionStripeAddTaxIdAction value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowActionStripeAddTaxIdAction ReadAsPropertyName(
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
            return new FlowActionStripeAddTaxIdAction(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionStripeAddTaxIdAction value,
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
        public const string AddTaxId = "ADD_TAX_ID";
    }
}
