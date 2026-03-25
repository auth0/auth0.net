using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionJsonCreateJsonType.FlowActionJsonCreateJsonTypeSerializer))]
[Serializable]
public readonly record struct FlowActionJsonCreateJsonType : IStringEnum
{
    public static readonly FlowActionJsonCreateJsonType Json = new(Values.Json);

    public FlowActionJsonCreateJsonType(string value)
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
    public static FlowActionJsonCreateJsonType FromCustom(string value)
    {
        return new FlowActionJsonCreateJsonType(value);
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

    public static bool operator ==(FlowActionJsonCreateJsonType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionJsonCreateJsonType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionJsonCreateJsonType value) => value.Value;

    public static explicit operator FlowActionJsonCreateJsonType(string value) => new(value);

    internal class FlowActionJsonCreateJsonTypeSerializer
        : JsonConverter<FlowActionJsonCreateJsonType>
    {
        public override FlowActionJsonCreateJsonType Read(
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
            return new FlowActionJsonCreateJsonType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionJsonCreateJsonType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowActionJsonCreateJsonType ReadAsPropertyName(
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
            return new FlowActionJsonCreateJsonType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionJsonCreateJsonType value,
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
        public const string Json = "JSON";
    }
}
