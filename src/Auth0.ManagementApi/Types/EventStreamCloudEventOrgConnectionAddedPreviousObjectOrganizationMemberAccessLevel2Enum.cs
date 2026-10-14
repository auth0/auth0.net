using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2EnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum
    : IStringEnum
{
    public static readonly EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum Limited =
        new(Values.Limited);

    public EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum(
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
    public static EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum(
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
        EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2EnumSerializer
        : JsonConverter<EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum>
    {
        public override EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum Read(
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
            return new EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum ReadAsPropertyName(
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
            return new EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum value,
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
