using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowActionAirtableListRecordsType.FlowActionAirtableListRecordsTypeSerializer)
)]
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

    internal class FlowActionAirtableListRecordsTypeSerializer
        : JsonConverter<FlowActionAirtableListRecordsType>
    {
        public override FlowActionAirtableListRecordsType Read(
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
            return new FlowActionAirtableListRecordsType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionAirtableListRecordsType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowActionAirtableListRecordsType ReadAsPropertyName(
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
            return new FlowActionAirtableListRecordsType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionAirtableListRecordsType value,
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
        public const string Airtable = "AIRTABLE";
    }
}
