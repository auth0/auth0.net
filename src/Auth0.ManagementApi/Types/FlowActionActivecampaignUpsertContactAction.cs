using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowActionActivecampaignUpsertContactAction.FlowActionActivecampaignUpsertContactActionSerializer)
)]
[Serializable]
public readonly record struct FlowActionActivecampaignUpsertContactAction : IStringEnum
{
    public static readonly FlowActionActivecampaignUpsertContactAction UpsertContact = new(
        Values.UpsertContact
    );

    public FlowActionActivecampaignUpsertContactAction(string value)
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
    public static FlowActionActivecampaignUpsertContactAction FromCustom(string value)
    {
        return new FlowActionActivecampaignUpsertContactAction(value);
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

    public static bool operator ==(
        FlowActionActivecampaignUpsertContactAction value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        FlowActionActivecampaignUpsertContactAction value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionActivecampaignUpsertContactAction value) =>
        value.Value;

    public static explicit operator FlowActionActivecampaignUpsertContactAction(string value) =>
        new(value);

    internal class FlowActionActivecampaignUpsertContactActionSerializer
        : JsonConverter<FlowActionActivecampaignUpsertContactAction>
    {
        public override FlowActionActivecampaignUpsertContactAction Read(
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
            return new FlowActionActivecampaignUpsertContactAction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionActivecampaignUpsertContactAction value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowActionActivecampaignUpsertContactAction ReadAsPropertyName(
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
            return new FlowActionActivecampaignUpsertContactAction(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionActivecampaignUpsertContactAction value,
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
