using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowActionHubspotUpsertContactType.FlowActionHubspotUpsertContactTypeSerializer)
)]
[Serializable]
public readonly record struct FlowActionHubspotUpsertContactType : IStringEnum
{
    public static readonly FlowActionHubspotUpsertContactType Hubspot = new(Values.Hubspot);

    public FlowActionHubspotUpsertContactType(string value)
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
    public static FlowActionHubspotUpsertContactType FromCustom(string value)
    {
        return new FlowActionHubspotUpsertContactType(value);
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

    public static bool operator ==(FlowActionHubspotUpsertContactType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionHubspotUpsertContactType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionHubspotUpsertContactType value) => value.Value;

    public static explicit operator FlowActionHubspotUpsertContactType(string value) => new(value);

    internal class FlowActionHubspotUpsertContactTypeSerializer
        : JsonConverter<FlowActionHubspotUpsertContactType>
    {
        public override FlowActionHubspotUpsertContactType Read(
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
            return new FlowActionHubspotUpsertContactType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionHubspotUpsertContactType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowActionHubspotUpsertContactType ReadAsPropertyName(
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
            return new FlowActionHubspotUpsertContactType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionHubspotUpsertContactType value,
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
        public const string Hubspot = "HUBSPOT";
    }
}
