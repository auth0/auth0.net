using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionAuth0SendEmailAction.FlowActionAuth0SendEmailActionSerializer))]
[Serializable]
public readonly record struct FlowActionAuth0SendEmailAction : IStringEnum
{
    public static readonly FlowActionAuth0SendEmailAction SendEmail = new(Values.SendEmail);

    public FlowActionAuth0SendEmailAction(string value)
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
    public static FlowActionAuth0SendEmailAction FromCustom(string value)
    {
        return new FlowActionAuth0SendEmailAction(value);
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

    public static bool operator ==(FlowActionAuth0SendEmailAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionAuth0SendEmailAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionAuth0SendEmailAction value) => value.Value;

    public static explicit operator FlowActionAuth0SendEmailAction(string value) => new(value);

    internal class FlowActionAuth0SendEmailActionSerializer
        : JsonConverter<FlowActionAuth0SendEmailAction>
    {
        public override FlowActionAuth0SendEmailAction Read(
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
            return new FlowActionAuth0SendEmailAction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionAuth0SendEmailAction value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowActionAuth0SendEmailAction ReadAsPropertyName(
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
            return new FlowActionAuth0SendEmailAction(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionAuth0SendEmailAction value,
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
