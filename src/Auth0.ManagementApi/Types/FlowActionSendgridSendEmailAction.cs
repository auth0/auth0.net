using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowActionSendgridSendEmailAction.FlowActionSendgridSendEmailActionSerializer)
)]
[Serializable]
public readonly record struct FlowActionSendgridSendEmailAction : IStringEnum
{
    public static readonly FlowActionSendgridSendEmailAction SendEmail = new(Values.SendEmail);

    public FlowActionSendgridSendEmailAction(string value)
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
    public static FlowActionSendgridSendEmailAction FromCustom(string value)
    {
        return new FlowActionSendgridSendEmailAction(value);
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

    public static bool operator ==(FlowActionSendgridSendEmailAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionSendgridSendEmailAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionSendgridSendEmailAction value) => value.Value;

    public static explicit operator FlowActionSendgridSendEmailAction(string value) => new(value);

    internal class FlowActionSendgridSendEmailActionSerializer
        : JsonConverter<FlowActionSendgridSendEmailAction>
    {
        public override FlowActionSendgridSendEmailAction Read(
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
            return new FlowActionSendgridSendEmailAction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionSendgridSendEmailAction value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowActionSendgridSendEmailAction ReadAsPropertyName(
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
            return new FlowActionSendgridSendEmailAction(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionSendgridSendEmailAction value,
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
