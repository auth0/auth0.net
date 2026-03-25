using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionHttpSendRequestAction.FlowActionHttpSendRequestActionSerializer))]
[Serializable]
public readonly record struct FlowActionHttpSendRequestAction : IStringEnum
{
    public static readonly FlowActionHttpSendRequestAction SendRequest = new(Values.SendRequest);

    public FlowActionHttpSendRequestAction(string value)
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
    public static FlowActionHttpSendRequestAction FromCustom(string value)
    {
        return new FlowActionHttpSendRequestAction(value);
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

    public static bool operator ==(FlowActionHttpSendRequestAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionHttpSendRequestAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionHttpSendRequestAction value) => value.Value;

    public static explicit operator FlowActionHttpSendRequestAction(string value) => new(value);

    internal class FlowActionHttpSendRequestActionSerializer
        : JsonConverter<FlowActionHttpSendRequestAction>
    {
        public override FlowActionHttpSendRequestAction Read(
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
            return new FlowActionHttpSendRequestAction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionHttpSendRequestAction value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowActionHttpSendRequestAction ReadAsPropertyName(
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
            return new FlowActionHttpSendRequestAction(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionHttpSendRequestAction value,
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
        public const string SendRequest = "SEND_REQUEST";
    }
}
