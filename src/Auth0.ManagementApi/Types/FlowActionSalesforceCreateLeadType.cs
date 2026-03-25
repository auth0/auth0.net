using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowActionSalesforceCreateLeadType.FlowActionSalesforceCreateLeadTypeSerializer)
)]
[Serializable]
public readonly record struct FlowActionSalesforceCreateLeadType : IStringEnum
{
    public static readonly FlowActionSalesforceCreateLeadType Salesforce = new(Values.Salesforce);

    public FlowActionSalesforceCreateLeadType(string value)
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
    public static FlowActionSalesforceCreateLeadType FromCustom(string value)
    {
        return new FlowActionSalesforceCreateLeadType(value);
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

    public static bool operator ==(FlowActionSalesforceCreateLeadType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionSalesforceCreateLeadType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionSalesforceCreateLeadType value) => value.Value;

    public static explicit operator FlowActionSalesforceCreateLeadType(string value) => new(value);

    internal class FlowActionSalesforceCreateLeadTypeSerializer
        : JsonConverter<FlowActionSalesforceCreateLeadType>
    {
        public override FlowActionSalesforceCreateLeadType Read(
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
            return new FlowActionSalesforceCreateLeadType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionSalesforceCreateLeadType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowActionSalesforceCreateLeadType ReadAsPropertyName(
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
            return new FlowActionSalesforceCreateLeadType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionSalesforceCreateLeadType value,
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
        public const string Salesforce = "SALESFORCE";
    }
}
