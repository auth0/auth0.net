using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3EnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum
    : IStringEnum
{
    public static readonly EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum Full =
        new(Values.Full);

    public EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum(
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
    public static EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum(
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
        EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3EnumSerializer
        : JsonConverter<EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum>
    {
        public override EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum Read(
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
            return new EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum ReadAsPropertyName(
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
            return new EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum value,
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
        public const string Full = "full";
    }
}
