using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowActionAirtableListRecordsAction>))]
[Serializable]
public readonly record struct FlowActionAirtableListRecordsAction : IStringEnum
{
    public static readonly FlowActionAirtableListRecordsAction ListRecords = new(
        Values.ListRecords
    );

    public FlowActionAirtableListRecordsAction(string value)
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
    public static FlowActionAirtableListRecordsAction FromCustom(string value)
    {
        return new FlowActionAirtableListRecordsAction(value);
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

    public static bool operator ==(FlowActionAirtableListRecordsAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionAirtableListRecordsAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionAirtableListRecordsAction value) =>
        value.Value;

    public static explicit operator FlowActionAirtableListRecordsAction(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string ListRecords = "LIST_RECORDS";
    }
}
