using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2EnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum
    : IStringEnum
{
    public static readonly EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum Limited =
        new(Values.Limited);

    public EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum(
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
    public static EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum(
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
        EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2EnumSerializer
        : JsonConverter<EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum>
    {
        public override EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum Read(
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
            return new EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum ReadAsPropertyName(
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
            return new EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum value,
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
