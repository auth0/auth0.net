using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionClearbitFindPersonType.FlowActionClearbitFindPersonTypeSerializer))]
[Serializable]
public readonly record struct FlowActionClearbitFindPersonType : IStringEnum
{
    public static readonly FlowActionClearbitFindPersonType Clearbit = new(Values.Clearbit);

    public FlowActionClearbitFindPersonType(string value)
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
    public static FlowActionClearbitFindPersonType FromCustom(string value)
    {
        return new FlowActionClearbitFindPersonType(value);
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

    public static bool operator ==(FlowActionClearbitFindPersonType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionClearbitFindPersonType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionClearbitFindPersonType value) => value.Value;

    public static explicit operator FlowActionClearbitFindPersonType(string value) => new(value);

    internal class FlowActionClearbitFindPersonTypeSerializer
        : JsonConverter<FlowActionClearbitFindPersonType>
    {
        public override FlowActionClearbitFindPersonType Read(
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
            return new FlowActionClearbitFindPersonType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionClearbitFindPersonType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowActionClearbitFindPersonType ReadAsPropertyName(
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
            return new FlowActionClearbitFindPersonType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionClearbitFindPersonType value,
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
        public const string Clearbit = "CLEARBIT";
    }
}
