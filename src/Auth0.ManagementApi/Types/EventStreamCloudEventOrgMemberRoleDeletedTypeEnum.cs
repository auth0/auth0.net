using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventOrgMemberRoleDeletedTypeEnum.EventStreamCloudEventOrgMemberRoleDeletedTypeEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventOrgMemberRoleDeletedTypeEnum : IStringEnum
{
    public static readonly EventStreamCloudEventOrgMemberRoleDeletedTypeEnum OrganizationMemberRoleDeleted =
        new(Values.OrganizationMemberRoleDeleted);

    public EventStreamCloudEventOrgMemberRoleDeletedTypeEnum(string value)
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
    public static EventStreamCloudEventOrgMemberRoleDeletedTypeEnum FromCustom(string value)
    {
        return new EventStreamCloudEventOrgMemberRoleDeletedTypeEnum(value);
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
        EventStreamCloudEventOrgMemberRoleDeletedTypeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventOrgMemberRoleDeletedTypeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventOrgMemberRoleDeletedTypeEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventOrgMemberRoleDeletedTypeEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventOrgMemberRoleDeletedTypeEnumSerializer
        : JsonConverter<EventStreamCloudEventOrgMemberRoleDeletedTypeEnum>
    {
        public override EventStreamCloudEventOrgMemberRoleDeletedTypeEnum Read(
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
            return new EventStreamCloudEventOrgMemberRoleDeletedTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgMemberRoleDeletedTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventOrgMemberRoleDeletedTypeEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventOrgMemberRoleDeletedTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgMemberRoleDeletedTypeEnum value,
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
