using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0EnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum
    : IStringEnum
{
    public static readonly EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum None =
        new(Values.None);

    public EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum(
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
    public static EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum(
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
        EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0EnumSerializer
        : JsonConverter<EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum>
    {
        public override EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum Read(
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
            return new EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum ReadAsPropertyName(
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
            return new EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum value,
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
        public const string None = "none";
    }
}
