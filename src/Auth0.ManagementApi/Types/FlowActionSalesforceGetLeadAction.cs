using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowActionSalesforceGetLeadAction.FlowActionSalesforceGetLeadActionSerializer)
)]
[Serializable]
public readonly record struct FlowActionSalesforceGetLeadAction : IStringEnum
{
    public static readonly FlowActionSalesforceGetLeadAction GetLead = new(Values.GetLead);

    public FlowActionSalesforceGetLeadAction(string value)
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
    public static FlowActionSalesforceGetLeadAction FromCustom(string value)
    {
        return new FlowActionSalesforceGetLeadAction(value);
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

    public static bool operator ==(FlowActionSalesforceGetLeadAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionSalesforceGetLeadAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionSalesforceGetLeadAction value) => value.Value;

    public static explicit operator FlowActionSalesforceGetLeadAction(string value) => new(value);

    internal class FlowActionSalesforceGetLeadActionSerializer
        : JsonConverter<FlowActionSalesforceGetLeadAction>
    {
        public override FlowActionSalesforceGetLeadAction Read(
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
            return new FlowActionSalesforceGetLeadAction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionSalesforceGetLeadAction value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowActionSalesforceGetLeadAction ReadAsPropertyName(
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
            return new FlowActionSalesforceGetLeadAction(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionSalesforceGetLeadAction value,
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
        public const string GetLead = "GET_LEAD";
    }
}
