using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionHttpSendRequestType.FlowActionHttpSendRequestTypeSerializer))]
[Serializable]
public readonly record struct FlowActionHttpSendRequestType : IStringEnum
{
    public static readonly FlowActionHttpSendRequestType Http = new(Values.Http);

    public FlowActionHttpSendRequestType(string value)
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
    public static FlowActionHttpSendRequestType FromCustom(string value)
    {
        return new FlowActionHttpSendRequestType(value);
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

    public static bool operator ==(FlowActionHttpSendRequestType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionHttpSendRequestType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionHttpSendRequestType value) => value.Value;

    public static explicit operator FlowActionHttpSendRequestType(string value) => new(value);

    internal class FlowActionHttpSendRequestTypeSerializer
        : JsonConverter<FlowActionHttpSendRequestType>
    {
        public override FlowActionHttpSendRequestType Read(
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
            return new FlowActionHttpSendRequestType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionHttpSendRequestType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowActionHttpSendRequestType ReadAsPropertyName(
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
            return new FlowActionHttpSendRequestType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionHttpSendRequestType value,
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
        public const string Http = "HTTP";
    }
}
