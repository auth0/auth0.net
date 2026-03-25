using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowActionSalesforceUpdateLeadAction.FlowActionSalesforceUpdateLeadActionSerializer)
)]
[Serializable]
public readonly record struct FlowActionSalesforceUpdateLeadAction : IStringEnum
{
    public static readonly FlowActionSalesforceUpdateLeadAction UpdateLead = new(Values.UpdateLead);

    public FlowActionSalesforceUpdateLeadAction(string value)
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
    public static FlowActionSalesforceUpdateLeadAction FromCustom(string value)
    {
        return new FlowActionSalesforceUpdateLeadAction(value);
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

    public static bool operator ==(FlowActionSalesforceUpdateLeadAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionSalesforceUpdateLeadAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionSalesforceUpdateLeadAction value) =>
        value.Value;

    public static explicit operator FlowActionSalesforceUpdateLeadAction(string value) =>
        new(value);

    internal class FlowActionSalesforceUpdateLeadActionSerializer
        : JsonConverter<FlowActionSalesforceUpdateLeadAction>
    {
        public override FlowActionSalesforceUpdateLeadAction Read(
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
            return new FlowActionSalesforceUpdateLeadAction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionSalesforceUpdateLeadAction value,
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
        public const string UpdateLead = "UPDATE_LEAD";
    }
}
