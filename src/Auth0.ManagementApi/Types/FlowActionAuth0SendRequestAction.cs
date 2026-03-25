using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionAuth0SendRequestAction.FlowActionAuth0SendRequestActionSerializer))]
[Serializable]
public readonly record struct FlowActionAuth0SendRequestAction : IStringEnum
{
    public static readonly FlowActionAuth0SendRequestAction SendRequest = new(Values.SendRequest);

    public FlowActionAuth0SendRequestAction(string value)
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
    public static FlowActionAuth0SendRequestAction FromCustom(string value)
    {
        return new FlowActionAuth0SendRequestAction(value);
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

    public static bool operator ==(FlowActionAuth0SendRequestAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionAuth0SendRequestAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionAuth0SendRequestAction value) => value.Value;

    public static explicit operator FlowActionAuth0SendRequestAction(string value) => new(value);

    internal class FlowActionAuth0SendRequestActionSerializer
        : JsonConverter<FlowActionAuth0SendRequestAction>
    {
        public override FlowActionAuth0SendRequestAction Read(
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
            return new FlowActionAuth0SendRequestAction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionAuth0SendRequestAction value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowActionAuth0SendRequestAction ReadAsPropertyName(
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
            return new FlowActionAuth0SendRequestAction(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionAuth0SendRequestAction value,
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
