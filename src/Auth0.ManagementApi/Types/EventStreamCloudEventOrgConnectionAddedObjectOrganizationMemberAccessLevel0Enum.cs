using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0EnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum
    : IStringEnum
{
    public static readonly EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum None =
        new(Values.None);

    public EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum(
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
    public static EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum(
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
        EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0EnumSerializer
        : JsonConverter<EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum>
    {
        public override EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum Read(
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
            return new EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum ReadAsPropertyName(
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
            return new EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum value,
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
