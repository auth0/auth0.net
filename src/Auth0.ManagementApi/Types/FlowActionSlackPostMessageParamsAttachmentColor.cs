using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowActionSlackPostMessageParamsAttachmentColor.FlowActionSlackPostMessageParamsAttachmentColorSerializer)
)]
[Serializable]
public readonly record struct FlowActionSlackPostMessageParamsAttachmentColor : IStringEnum
{
    public static readonly FlowActionSlackPostMessageParamsAttachmentColor Good = new(Values.Good);

    public static readonly FlowActionSlackPostMessageParamsAttachmentColor Warning = new(
        Values.Warning
    );

    public static readonly FlowActionSlackPostMessageParamsAttachmentColor Danger = new(
        Values.Danger
    );

    public FlowActionSlackPostMessageParamsAttachmentColor(string value)
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
    public static FlowActionSlackPostMessageParamsAttachmentColor FromCustom(string value)
    {
        return new FlowActionSlackPostMessageParamsAttachmentColor(value);
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

    public static bool operator ==(
        FlowActionSlackPostMessageParamsAttachmentColor value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        FlowActionSlackPostMessageParamsAttachmentColor value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionSlackPostMessageParamsAttachmentColor value) =>
        value.Value;

    public static explicit operator FlowActionSlackPostMessageParamsAttachmentColor(string value) =>
        new(value);

    internal class FlowActionSlackPostMessageParamsAttachmentColorSerializer
        : JsonConverter<FlowActionSlackPostMessageParamsAttachmentColor>
    {
        public override FlowActionSlackPostMessageParamsAttachmentColor Read(
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
            return new FlowActionSlackPostMessageParamsAttachmentColor(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionSlackPostMessageParamsAttachmentColor value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowActionSlackPostMessageParamsAttachmentColor ReadAsPropertyName(
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
            return new FlowActionSlackPostMessageParamsAttachmentColor(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionSlackPostMessageParamsAttachmentColor value,
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
        public const string Good = "GOOD";

        public const string Warning = "WARNING";

        public const string Danger = "DANGER";
    }
}
