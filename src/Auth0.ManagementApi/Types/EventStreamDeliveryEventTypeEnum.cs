using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(EventStreamDeliveryEventTypeEnum.EventStreamDeliveryEventTypeEnumSerializer))]
[Serializable]
public readonly record struct EventStreamDeliveryEventTypeEnum : IStringEnum
{
    public static readonly EventStreamDeliveryEventTypeEnum UserCreated = new(Values.UserCreated);

    public static readonly EventStreamDeliveryEventTypeEnum UserDeleted = new(Values.UserDeleted);

    public static readonly EventStreamDeliveryEventTypeEnum UserUpdated = new(Values.UserUpdated);

    public static readonly EventStreamDeliveryEventTypeEnum OrganizationCreated = new(
        Values.OrganizationCreated
    );

    public static readonly EventStreamDeliveryEventTypeEnum OrganizationUpdated = new(
        Values.OrganizationUpdated
    );

    public static readonly EventStreamDeliveryEventTypeEnum OrganizationDeleted = new(
        Values.OrganizationDeleted
    );

    public static readonly EventStreamDeliveryEventTypeEnum OrganizationMemberAdded = new(
        Values.OrganizationMemberAdded
    );

    public static readonly EventStreamDeliveryEventTypeEnum OrganizationMemberDeleted = new(
        Values.OrganizationMemberDeleted
    );

    public static readonly EventStreamDeliveryEventTypeEnum OrganizationMemberRoleAssigned = new(
        Values.OrganizationMemberRoleAssigned
    );

    public static readonly EventStreamDeliveryEventTypeEnum OrganizationMemberRoleDeleted = new(
        Values.OrganizationMemberRoleDeleted
    );

    public static readonly EventStreamDeliveryEventTypeEnum OrganizationConnectionAdded = new(
        Values.OrganizationConnectionAdded
    );

    public static readonly EventStreamDeliveryEventTypeEnum OrganizationConnectionUpdated = new(
        Values.OrganizationConnectionUpdated
    );

    public static readonly EventStreamDeliveryEventTypeEnum OrganizationConnectionRemoved = new(
        Values.OrganizationConnectionRemoved
    );

    public static readonly EventStreamDeliveryEventTypeEnum GroupCreated = new(Values.GroupCreated);

    public static readonly EventStreamDeliveryEventTypeEnum GroupUpdated = new(Values.GroupUpdated);

    public static readonly EventStreamDeliveryEventTypeEnum GroupDeleted = new(Values.GroupDeleted);

    public static readonly EventStreamDeliveryEventTypeEnum GroupMemberAdded = new(
        Values.GroupMemberAdded
    );

    public static readonly EventStreamDeliveryEventTypeEnum GroupMemberDeleted = new(
        Values.GroupMemberDeleted
    );

    public EventStreamDeliveryEventTypeEnum(string value)
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
    public static EventStreamDeliveryEventTypeEnum FromCustom(string value)
    {
        return new EventStreamDeliveryEventTypeEnum(value);
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

    public static bool operator ==(EventStreamDeliveryEventTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(EventStreamDeliveryEventTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EventStreamDeliveryEventTypeEnum value) => value.Value;

    public static explicit operator EventStreamDeliveryEventTypeEnum(string value) => new(value);

    internal class EventStreamDeliveryEventTypeEnumSerializer
        : JsonConverter<EventStreamDeliveryEventTypeEnum>
    {
        public override EventStreamDeliveryEventTypeEnum Read(
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
            return new EventStreamDeliveryEventTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamDeliveryEventTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamDeliveryEventTypeEnum ReadAsPropertyName(
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
            return new EventStreamDeliveryEventTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamDeliveryEventTypeEnum value,
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
        public const string UserCreated = "user.created";

        public const string UserDeleted = "user.deleted";

        public const string UserUpdated = "user.updated";

        public const string OrganizationCreated = "organization.created";

        public const string OrganizationUpdated = "organization.updated";

        public const string OrganizationDeleted = "organization.deleted";

        public const string OrganizationMemberAdded = "organization.member.added";

        public const string OrganizationMemberDeleted = "organization.member.deleted";

        public const string OrganizationMemberRoleAssigned = "organization.member.role.assigned";

        public const string OrganizationMemberRoleDeleted = "organization.member.role.deleted";

        public const string OrganizationConnectionAdded = "organization.connection.added";

        public const string OrganizationConnectionUpdated = "organization.connection.updated";

        public const string OrganizationConnectionRemoved = "organization.connection.removed";

        public const string GroupCreated = "group.created";

        public const string GroupUpdated = "group.updated";

        public const string GroupDeleted = "group.deleted";

        public const string GroupMemberAdded = "group.member.added";

        public const string GroupMemberDeleted = "group.member.deleted";
    }
}
