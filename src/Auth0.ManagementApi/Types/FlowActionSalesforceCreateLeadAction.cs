using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowActionSalesforceCreateLeadAction.FlowActionSalesforceCreateLeadActionSerializer)
)]
[Serializable]
public readonly record struct FlowActionSalesforceCreateLeadAction : IStringEnum
{
    public static readonly FlowActionSalesforceCreateLeadAction CreateLead = new(Values.CreateLead);

    public FlowActionSalesforceCreateLeadAction(string value)
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
    public static FlowActionSalesforceCreateLeadAction FromCustom(string value)
    {
        return new FlowActionSalesforceCreateLeadAction(value);
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

    public static bool operator ==(FlowActionSalesforceCreateLeadAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionSalesforceCreateLeadAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionSalesforceCreateLeadAction value) =>
        value.Value;

    public static explicit operator FlowActionSalesforceCreateLeadAction(string value) =>
        new(value);

    internal class FlowActionSalesforceCreateLeadActionSerializer
        : JsonConverter<FlowActionSalesforceCreateLeadAction>
    {
        public override FlowActionSalesforceCreateLeadAction Read(
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
            return new FlowActionSalesforceCreateLeadAction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionSalesforceCreateLeadAction value,
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
        public const string CreateLead = "CREATE_LEAD";
    }
}
