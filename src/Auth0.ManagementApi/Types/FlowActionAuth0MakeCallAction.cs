using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionAuth0MakeCallAction.FlowActionAuth0MakeCallActionSerializer))]
[Serializable]
public readonly record struct FlowActionAuth0MakeCallAction : IStringEnum
{
    public static readonly FlowActionAuth0MakeCallAction MakeCall = new(Values.MakeCall);

    public FlowActionAuth0MakeCallAction(string value)
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
    public static FlowActionAuth0MakeCallAction FromCustom(string value)
    {
        return new FlowActionAuth0MakeCallAction(value);
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

    public static bool operator ==(FlowActionAuth0MakeCallAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionAuth0MakeCallAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionAuth0MakeCallAction value) => value.Value;

    public static explicit operator FlowActionAuth0MakeCallAction(string value) => new(value);

    internal class FlowActionAuth0MakeCallActionSerializer
        : JsonConverter<FlowActionAuth0MakeCallAction>
    {
        public override FlowActionAuth0MakeCallAction Read(
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
            return new FlowActionAuth0MakeCallAction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionAuth0MakeCallAction value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowActionAuth0MakeCallAction ReadAsPropertyName(
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
            return new FlowActionAuth0MakeCallAction(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionAuth0MakeCallAction value,
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
        public const string MakeCall = "MAKE_CALL";
    }
}
