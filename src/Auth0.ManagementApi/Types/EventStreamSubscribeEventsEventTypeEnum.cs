using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamSubscribeEventsEventTypeEnum.EventStreamSubscribeEventsEventTypeEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamSubscribeEventsEventTypeEnum : IStringEnum
{
    public static readonly EventStreamSubscribeEventsEventTypeEnum GroupCreated = new(
        Values.GroupCreated
    );

    public static readonly EventStreamSubscribeEventsEventTypeEnum GroupDeleted = new(
        Values.GroupDeleted
    );

    public static readonly EventStreamSubscribeEventsEventTypeEnum GroupMemberAdded = new(
        Values.GroupMemberAdded
    );

    public static readonly EventStreamSubscribeEventsEventTypeEnum GroupMemberDeleted = new(
        Values.GroupMemberDeleted
    );

    public static readonly EventStreamSubscribeEventsEventTypeEnum GroupRoleAssigned = new(
        Values.GroupRoleAssigned
    );

    public static readonly EventStreamSubscribeEventsEventTypeEnum GroupRoleDeleted = new(
        Values.GroupRoleDeleted
    );

    public static readonly EventStreamSubscribeEventsEventTypeEnum GroupUpdated = new(
        Values.GroupUpdated
    );

    public static readonly EventStreamSubscribeEventsEventTypeEnum OrganizationConnectionAdded =
        new(Values.OrganizationConnectionAdded);

    public static readonly EventStreamSubscribeEventsEventTypeEnum OrganizationConnectionRemoved =
        new(Values.OrganizationConnectionRemoved);

    public static readonly EventStreamSubscribeEventsEventTypeEnum OrganizationConnectionUpdated =
        new(Values.OrganizationConnectionUpdated);

    public static readonly EventStreamSubscribeEventsEventTypeEnum OrganizationCreated = new(
        Values.OrganizationCreated
    );

    public static readonly EventStreamSubscribeEventsEventTypeEnum OrganizationDeleted = new(
        Values.OrganizationDeleted
    );

    public static readonly EventStreamSubscribeEventsEventTypeEnum OrganizationGroupRoleAssigned =
        new(Values.OrganizationGroupRoleAssigned);

    public static readonly EventStreamSubscribeEventsEventTypeEnum OrganizationGroupRoleDeleted =
        new(Values.OrganizationGroupRoleDeleted);

    public static readonly EventStreamSubscribeEventsEventTypeEnum OrganizationMemberAdded = new(
        Values.OrganizationMemberAdded
    );

    public static readonly EventStreamSubscribeEventsEventTypeEnum OrganizationMemberDeleted = new(
        Values.OrganizationMemberDeleted
    );

    public static readonly EventStreamSubscribeEventsEventTypeEnum OrganizationMemberRoleAssigned =
        new(Values.OrganizationMemberRoleAssigned);

    public static readonly EventStreamSubscribeEventsEventTypeEnum OrganizationMemberRoleDeleted =
        new(Values.OrganizationMemberRoleDeleted);

    public static readonly EventStreamSubscribeEventsEventTypeEnum OrganizationUpdated = new(
        Values.OrganizationUpdated
    );

    public static readonly EventStreamSubscribeEventsEventTypeEnum UserCreated = new(
        Values.UserCreated
    );

    public static readonly EventStreamSubscribeEventsEventTypeEnum UserDeleted = new(
        Values.UserDeleted
    );

    public static readonly EventStreamSubscribeEventsEventTypeEnum UserUpdated = new(
        Values.UserUpdated
    );

    public EventStreamSubscribeEventsEventTypeEnum(string value)
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
    public static EventStreamSubscribeEventsEventTypeEnum FromCustom(string value)
    {
        return new EventStreamSubscribeEventsEventTypeEnum(value);
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

    public static bool operator ==(EventStreamSubscribeEventsEventTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(EventStreamSubscribeEventsEventTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EventStreamSubscribeEventsEventTypeEnum value) =>
        value.Value;

    public static explicit operator EventStreamSubscribeEventsEventTypeEnum(string value) =>
        new(value);

    internal class EventStreamSubscribeEventsEventTypeEnumSerializer
        : JsonConverter<EventStreamSubscribeEventsEventTypeEnum>
    {
        public override EventStreamSubscribeEventsEventTypeEnum Read(
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
            return new EventStreamSubscribeEventsEventTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamSubscribeEventsEventTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamSubscribeEventsEventTypeEnum ReadAsPropertyName(
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
            return new EventStreamSubscribeEventsEventTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamSubscribeEventsEventTypeEnum value,
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
        public const string GroupCreated = "group.created";

        public const string GroupDeleted = "group.deleted";

        public const string GroupMemberAdded = "group.member.added";

        public const string GroupMemberDeleted = "group.member.deleted";

        public const string GroupRoleAssigned = "group.role.assigned";

        public const string GroupRoleDeleted = "group.role.deleted";

        public const string GroupUpdated = "group.updated";

        public const string OrganizationConnectionAdded = "organization.connection.added";

        public const string OrganizationConnectionRemoved = "organization.connection.removed";

        public const string OrganizationConnectionUpdated = "organization.connection.updated";

        public const string OrganizationCreated = "organization.created";

        public const string OrganizationDeleted = "organization.deleted";

        public const string OrganizationGroupRoleAssigned = "organization.group.role.assigned";

        public const string OrganizationGroupRoleDeleted = "organization.group.role.deleted";

        public const string OrganizationMemberAdded = "organization.member.added";

        public const string OrganizationMemberDeleted = "organization.member.deleted";

        public const string OrganizationMemberRoleAssigned = "organization.member.role.assigned";

        public const string OrganizationMemberRoleDeleted = "organization.member.role.deleted";

        public const string OrganizationUpdated = "organization.updated";

        public const string UserCreated = "user.created";

        public const string UserDeleted = "user.deleted";

        public const string UserUpdated = "user.updated";
    }
}
