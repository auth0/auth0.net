using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0EnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum
    : IStringEnum
{
    public static readonly EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum None =
        new(Values.None);

    public EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum(
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
    public static EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum(
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
        EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0EnumSerializer
        : JsonConverter<EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum>
    {
        public override EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum Read(
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
            return new EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum ReadAsPropertyName(
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
            return new EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum value,
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
