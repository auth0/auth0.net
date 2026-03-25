using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(EventStreamEventTypeEnum.EventStreamEventTypeEnumSerializer))]
[Serializable]
public readonly record struct EventStreamEventTypeEnum : IStringEnum
{
    public static readonly EventStreamEventTypeEnum UserCreated = new(Values.UserCreated);

    public static readonly EventStreamEventTypeEnum UserDeleted = new(Values.UserDeleted);

    public static readonly EventStreamEventTypeEnum UserUpdated = new(Values.UserUpdated);

    public static readonly EventStreamEventTypeEnum OrganizationCreated = new(
        Values.OrganizationCreated
    );

    public static readonly EventStreamEventTypeEnum OrganizationUpdated = new(
        Values.OrganizationUpdated
    );

    public static readonly EventStreamEventTypeEnum OrganizationDeleted = new(
        Values.OrganizationDeleted
    );

    public static readonly EventStreamEventTypeEnum OrganizationMemberAdded = new(
        Values.OrganizationMemberAdded
    );

    public static readonly EventStreamEventTypeEnum OrganizationMemberDeleted = new(
        Values.OrganizationMemberDeleted
    );

    public static readonly EventStreamEventTypeEnum OrganizationMemberRoleAssigned = new(
        Values.OrganizationMemberRoleAssigned
    );

    public static readonly EventStreamEventTypeEnum OrganizationMemberRoleDeleted = new(
        Values.OrganizationMemberRoleDeleted
    );

    public static readonly EventStreamEventTypeEnum OrganizationConnectionAdded = new(
        Values.OrganizationConnectionAdded
    );

    public static readonly EventStreamEventTypeEnum OrganizationConnectionUpdated = new(
        Values.OrganizationConnectionUpdated
    );

    public static readonly EventStreamEventTypeEnum OrganizationConnectionRemoved = new(
        Values.OrganizationConnectionRemoved
    );

    public static readonly EventStreamEventTypeEnum GroupCreated = new(Values.GroupCreated);

    public static readonly EventStreamEventTypeEnum GroupUpdated = new(Values.GroupUpdated);

    public static readonly EventStreamEventTypeEnum GroupDeleted = new(Values.GroupDeleted);

    public static readonly EventStreamEventTypeEnum GroupMemberAdded = new(Values.GroupMemberAdded);

    public static readonly EventStreamEventTypeEnum GroupMemberDeleted = new(
        Values.GroupMemberDeleted
    );

    public EventStreamEventTypeEnum(string value)
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
    public static EventStreamEventTypeEnum FromCustom(string value)
    {
        return new EventStreamEventTypeEnum(value);
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

    public static bool operator ==(EventStreamEventTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(EventStreamEventTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EventStreamEventTypeEnum value) => value.Value;

    public static explicit operator EventStreamEventTypeEnum(string value) => new(value);

    internal class EventStreamEventTypeEnumSerializer : JsonConverter<EventStreamEventTypeEnum>
    {
        public override EventStreamEventTypeEnum Read(
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
            return new EventStreamEventTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamEventTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
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
