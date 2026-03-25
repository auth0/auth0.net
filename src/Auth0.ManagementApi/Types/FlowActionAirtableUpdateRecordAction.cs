using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowActionAirtableUpdateRecordAction.FlowActionAirtableUpdateRecordActionSerializer)
)]
[Serializable]
public readonly record struct FlowActionAirtableUpdateRecordAction : IStringEnum
{
    public static readonly FlowActionAirtableUpdateRecordAction UpdateRecord = new(
        Values.UpdateRecord
    );

    public FlowActionAirtableUpdateRecordAction(string value)
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
    public static FlowActionAirtableUpdateRecordAction FromCustom(string value)
    {
        return new FlowActionAirtableUpdateRecordAction(value);
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

    public static bool operator ==(FlowActionAirtableUpdateRecordAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionAirtableUpdateRecordAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionAirtableUpdateRecordAction value) =>
        value.Value;

    public static explicit operator FlowActionAirtableUpdateRecordAction(string value) =>
        new(value);

    internal class FlowActionAirtableUpdateRecordActionSerializer
        : JsonConverter<FlowActionAirtableUpdateRecordAction>
    {
        public override FlowActionAirtableUpdateRecordAction Read(
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
            return new FlowActionAirtableUpdateRecordAction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionAirtableUpdateRecordAction value,
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
        public const string UpdateRecord = "UPDATE_RECORD";
    }
}
