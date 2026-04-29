using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventOrgMemberRoleDeletedCloudEventTypeEnum.EventStreamCloudEventOrgMemberRoleDeletedCloudEventTypeEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventOrgMemberRoleDeletedCloudEventTypeEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventOrgMemberRoleDeletedCloudEventTypeEnum OrganizationMemberRoleDeleted =
        new(Values.OrganizationMemberRoleDeleted);

    public EventStreamCloudEventOrgMemberRoleDeletedCloudEventTypeEnum(string value)
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
    public static EventStreamCloudEventOrgMemberRoleDeletedCloudEventTypeEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventOrgMemberRoleDeletedCloudEventTypeEnum(value);
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
        EventStreamCloudEventOrgMemberRoleDeletedCloudEventTypeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventOrgMemberRoleDeletedCloudEventTypeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventOrgMemberRoleDeletedCloudEventTypeEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventOrgMemberRoleDeletedCloudEventTypeEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventOrgMemberRoleDeletedCloudEventTypeEnumSerializer
        : JsonConverter<EventStreamCloudEventOrgMemberRoleDeletedCloudEventTypeEnum>
    {
        public override EventStreamCloudEventOrgMemberRoleDeletedCloudEventTypeEnum Read(
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
            return new EventStreamCloudEventOrgMemberRoleDeletedCloudEventTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgMemberRoleDeletedCloudEventTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventOrgMemberRoleDeletedCloudEventTypeEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventOrgMemberRoleDeletedCloudEventTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgMemberRoleDeletedCloudEventTypeEnum value,
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
        public const string OrganizationMemberRoleDeleted = "organization.member.role.deleted";
    }
}
