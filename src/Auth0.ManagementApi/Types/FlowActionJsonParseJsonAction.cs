using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionJsonParseJsonAction.FlowActionJsonParseJsonActionSerializer))]
[Serializable]
public readonly record struct FlowActionJsonParseJsonAction : IStringEnum
{
    public static readonly FlowActionJsonParseJsonAction ParseJson = new(Values.ParseJson);

    public FlowActionJsonParseJsonAction(string value)
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
    public static FlowActionJsonParseJsonAction FromCustom(string value)
    {
        return new FlowActionJsonParseJsonAction(value);
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

    public static bool operator ==(FlowActionJsonParseJsonAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionJsonParseJsonAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionJsonParseJsonAction value) => value.Value;

    public static explicit operator FlowActionJsonParseJsonAction(string value) => new(value);

    internal class FlowActionJsonParseJsonActionSerializer
        : JsonConverter<FlowActionJsonParseJsonAction>
    {
        public override FlowActionJsonParseJsonAction Read(
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
            return new FlowActionJsonParseJsonAction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionJsonParseJsonAction value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowActionJsonParseJsonAction ReadAsPropertyName(
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
            return new FlowActionJsonParseJsonAction(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionJsonParseJsonAction value,
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
        public const string ParseJson = "PARSE_JSON";
    }
}
