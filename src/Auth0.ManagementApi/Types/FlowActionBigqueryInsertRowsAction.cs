using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowActionBigqueryInsertRowsAction.FlowActionBigqueryInsertRowsActionSerializer)
)]
[Serializable]
public readonly record struct FlowActionBigqueryInsertRowsAction : IStringEnum
{
    public static readonly FlowActionBigqueryInsertRowsAction InsertRows = new(Values.InsertRows);

    public FlowActionBigqueryInsertRowsAction(string value)
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
    public static FlowActionBigqueryInsertRowsAction FromCustom(string value)
    {
        return new FlowActionBigqueryInsertRowsAction(value);
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

    public static bool operator ==(FlowActionBigqueryInsertRowsAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionBigqueryInsertRowsAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionBigqueryInsertRowsAction value) => value.Value;

    public static explicit operator FlowActionBigqueryInsertRowsAction(string value) => new(value);

    internal class FlowActionBigqueryInsertRowsActionSerializer
        : JsonConverter<FlowActionBigqueryInsertRowsAction>
    {
        public override FlowActionBigqueryInsertRowsAction Read(
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
            return new FlowActionBigqueryInsertRowsAction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionBigqueryInsertRowsAction value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowActionBigqueryInsertRowsAction ReadAsPropertyName(
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
            return new FlowActionBigqueryInsertRowsAction(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionBigqueryInsertRowsAction value,
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
        public const string InsertRows = "INSERT_ROWS";
    }
}
