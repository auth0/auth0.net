using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowActionActivecampaignListContactsAction.FlowActionActivecampaignListContactsActionSerializer)
)]
[Serializable]
public readonly record struct FlowActionActivecampaignListContactsAction : IStringEnum
{
    public static readonly FlowActionActivecampaignListContactsAction ListContacts = new(
        Values.ListContacts
    );

    public FlowActionActivecampaignListContactsAction(string value)
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
    public static FlowActionActivecampaignListContactsAction FromCustom(string value)
    {
        return new FlowActionActivecampaignListContactsAction(value);
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
        FlowActionActivecampaignListContactsAction value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        FlowActionActivecampaignListContactsAction value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionActivecampaignListContactsAction value) =>
        value.Value;

    public static explicit operator FlowActionActivecampaignListContactsAction(string value) =>
        new(value);

    internal class FlowActionActivecampaignListContactsActionSerializer
        : JsonConverter<FlowActionActivecampaignListContactsAction>
    {
        public override FlowActionActivecampaignListContactsAction Read(
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
            return new FlowActionActivecampaignListContactsAction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionActivecampaignListContactsAction value,
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
        public const string ListContacts = "LIST_CONTACTS";
    }
}
