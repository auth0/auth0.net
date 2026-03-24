using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowActionJsonSerializeJsonAction.FlowActionJsonSerializeJsonActionSerializer)
)]
[Serializable]
public readonly record struct FlowActionJsonSerializeJsonAction : IStringEnum
{
    public static readonly FlowActionJsonSerializeJsonAction SerializeJson = new(
        Values.SerializeJson
    );

    public FlowActionJsonSerializeJsonAction(string value)
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
    public static FlowActionJsonSerializeJsonAction FromCustom(string value)
    {
        return new FlowActionJsonSerializeJsonAction(value);
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

    public static bool operator ==(FlowActionJsonSerializeJsonAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionJsonSerializeJsonAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionJsonSerializeJsonAction value) => value.Value;

    public static explicit operator FlowActionJsonSerializeJsonAction(string value) => new(value);

    internal class FlowActionJsonSerializeJsonActionSerializer
        : JsonConverter<FlowActionJsonSerializeJsonAction>
    {
        public override FlowActionJsonSerializeJsonAction Read(
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
            return new FlowActionJsonSerializeJsonAction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionJsonSerializeJsonAction value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string SerializeJson = "SERIALIZE_JSON";
    }
}
