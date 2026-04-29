using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventOrgGroupRoleDeletedTypeEnum.EventStreamCloudEventOrgGroupRoleDeletedTypeEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventOrgGroupRoleDeletedTypeEnum : IStringEnum
{
    public static readonly EventStreamCloudEventOrgGroupRoleDeletedTypeEnum OrganizationGroupRoleDeleted =
        new(Values.OrganizationGroupRoleDeleted);

    public EventStreamCloudEventOrgGroupRoleDeletedTypeEnum(string value)
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
    public static EventStreamCloudEventOrgGroupRoleDeletedTypeEnum FromCustom(string value)
    {
        return new EventStreamCloudEventOrgGroupRoleDeletedTypeEnum(value);
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
        EventStreamCloudEventOrgGroupRoleDeletedTypeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventOrgGroupRoleDeletedTypeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventOrgGroupRoleDeletedTypeEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventOrgGroupRoleDeletedTypeEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventOrgGroupRoleDeletedTypeEnumSerializer
        : JsonConverter<EventStreamCloudEventOrgGroupRoleDeletedTypeEnum>
    {
        public override EventStreamCloudEventOrgGroupRoleDeletedTypeEnum Read(
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
            return new EventStreamCloudEventOrgGroupRoleDeletedTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgGroupRoleDeletedTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventOrgGroupRoleDeletedTypeEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventOrgGroupRoleDeletedTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgGroupRoleDeletedTypeEnum value,
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
        public const string OrganizationGroupRoleDeleted = "organization.group.role.deleted";
    }
}
