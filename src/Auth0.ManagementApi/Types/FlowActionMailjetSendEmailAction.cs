using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionMailjetSendEmailAction.FlowActionMailjetSendEmailActionSerializer))]
[Serializable]
public readonly record struct FlowActionMailjetSendEmailAction : IStringEnum
{
    public static readonly FlowActionMailjetSendEmailAction SendEmail = new(Values.SendEmail);

    public FlowActionMailjetSendEmailAction(string value)
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
    public static FlowActionMailjetSendEmailAction FromCustom(string value)
    {
        return new FlowActionMailjetSendEmailAction(value);
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

    public static bool operator ==(FlowActionMailjetSendEmailAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionMailjetSendEmailAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionMailjetSendEmailAction value) => value.Value;

    public static explicit operator FlowActionMailjetSendEmailAction(string value) => new(value);

    internal class FlowActionMailjetSendEmailActionSerializer
        : JsonConverter<FlowActionMailjetSendEmailAction>
    {
        public override FlowActionMailjetSendEmailAction Read(
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
            return new FlowActionMailjetSendEmailAction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionMailjetSendEmailAction value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowActionMailjetSendEmailAction ReadAsPropertyName(
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
            return new FlowActionMailjetSendEmailAction(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionMailjetSendEmailAction value,
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
        public const string SendEmail = "SEND_EMAIL";
    }
}
