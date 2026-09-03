using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2EnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum
    : IStringEnum
{
    public static readonly EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum Limited =
        new(Values.Limited);

    public EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum(
        string value
    )
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
    public static EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum(
            value
        );
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
        EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2EnumSerializer
        : JsonConverter<EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum>
    {
        public override EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum Read(
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
            return new EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum ReadAsPropertyName(
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
            return new EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum value,
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
        public const string Limited = "limited";
    }
}
