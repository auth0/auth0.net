using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowActionAirtableListRecordsAction.FlowActionAirtableListRecordsActionSerializer)
)]
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

    internal class FlowActionAirtableListRecordsActionSerializer
        : JsonConverter<FlowActionAirtableListRecordsAction>
    {
        public override FlowActionAirtableListRecordsAction Read(
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
            return new FlowActionAirtableListRecordsAction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionAirtableListRecordsAction value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowActionAirtableListRecordsAction ReadAsPropertyName(
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
            return new FlowActionAirtableListRecordsAction(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionAirtableListRecordsAction value,
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
        public const string ListRecords = "LIST_RECORDS";
    }
}
