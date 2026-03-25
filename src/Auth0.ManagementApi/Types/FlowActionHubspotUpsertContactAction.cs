using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowActionHubspotUpsertContactAction.FlowActionHubspotUpsertContactActionSerializer)
)]
[Serializable]
public readonly record struct FlowActionHubspotUpsertContactAction : IStringEnum
{
    public static readonly FlowActionHubspotUpsertContactAction UpsertContact = new(
        Values.UpsertContact
    );

    public FlowActionHubspotUpsertContactAction(string value)
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
    public static FlowActionHubspotUpsertContactAction FromCustom(string value)
    {
        return new FlowActionHubspotUpsertContactAction(value);
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

    public static bool operator ==(FlowActionHubspotUpsertContactAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionHubspotUpsertContactAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionHubspotUpsertContactAction value) =>
        value.Value;

    public static explicit operator FlowActionHubspotUpsertContactAction(string value) =>
        new(value);

    internal class FlowActionHubspotUpsertContactActionSerializer
        : JsonConverter<FlowActionHubspotUpsertContactAction>
    {
        public override FlowActionHubspotUpsertContactAction Read(
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
            return new FlowActionHubspotUpsertContactAction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionHubspotUpsertContactAction value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowActionHubspotUpsertContactAction ReadAsPropertyName(
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
            return new FlowActionHubspotUpsertContactAction(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionHubspotUpsertContactAction value,
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
        public const string UpsertContact = "UPSERT_CONTACT";
    }
}
