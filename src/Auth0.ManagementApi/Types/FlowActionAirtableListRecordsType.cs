using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowActionAirtableListRecordsType>))]
[Serializable]
public readonly record struct FlowActionAirtableListRecordsType : IStringEnum
{
    public static readonly FlowActionAirtableListRecordsType Airtable = new(Values.Airtable);

    public FlowActionAirtableListRecordsType(string value)
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
    public static FlowActionAirtableListRecordsType FromCustom(string value)
    {
        return new FlowActionAirtableListRecordsType(value);
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

    public static bool operator ==(FlowActionAirtableListRecordsType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionAirtableListRecordsType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionAirtableListRecordsType value) => value.Value;

    public static explicit operator FlowActionAirtableListRecordsType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Airtable = "AIRTABLE";
    }
}
