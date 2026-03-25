using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(EventStreamTestEventTypeEnum.EventStreamTestEventTypeEnumSerializer))]
[Serializable]
public readonly record struct EventStreamTestEventTypeEnum : IStringEnum
{
    public static readonly EventStreamTestEventTypeEnum UserCreated = new(Values.UserCreated);

    public static readonly EventStreamTestEventTypeEnum UserDeleted = new(Values.UserDeleted);

    public static readonly EventStreamTestEventTypeEnum UserUpdated = new(Values.UserUpdated);

    public static readonly EventStreamTestEventTypeEnum OrganizationCreated = new(
        Values.OrganizationCreated
    );

    public static readonly EventStreamTestEventTypeEnum OrganizationUpdated = new(
        Values.OrganizationUpdated
    );

    public static readonly EventStreamTestEventTypeEnum OrganizationDeleted = new(
        Values.OrganizationDeleted
    );

    public static readonly EventStreamTestEventTypeEnum OrganizationMemberAdded = new(
        Values.OrganizationMemberAdded
    );

    public static readonly EventStreamTestEventTypeEnum OrganizationMemberDeleted = new(
        Values.OrganizationMemberDeleted
    );

    public static readonly EventStreamTestEventTypeEnum OrganizationMemberRoleAssigned = new(
        Values.OrganizationMemberRoleAssigned
    );

    public static readonly EventStreamTestEventTypeEnum OrganizationMemberRoleDeleted = new(
        Values.OrganizationMemberRoleDeleted
    );

    public static readonly EventStreamTestEventTypeEnum OrganizationConnectionAdded = new(
        Values.OrganizationConnectionAdded
    );

    public static readonly EventStreamTestEventTypeEnum OrganizationConnectionUpdated = new(
        Values.OrganizationConnectionUpdated
    );

    public static readonly EventStreamTestEventTypeEnum OrganizationConnectionRemoved = new(
        Values.OrganizationConnectionRemoved
    );

    public static readonly EventStreamTestEventTypeEnum GroupCreated = new(Values.GroupCreated);

    public static readonly EventStreamTestEventTypeEnum GroupUpdated = new(Values.GroupUpdated);

    public static readonly EventStreamTestEventTypeEnum GroupDeleted = new(Values.GroupDeleted);

    public static readonly EventStreamTestEventTypeEnum GroupMemberAdded = new(
        Values.GroupMemberAdded
    );

    public static readonly EventStreamTestEventTypeEnum GroupMemberDeleted = new(
        Values.GroupMemberDeleted
    );

    public EventStreamTestEventTypeEnum(string value)
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
    public static EventStreamTestEventTypeEnum FromCustom(string value)
    {
        return new EventStreamTestEventTypeEnum(value);
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

    public static bool operator ==(EventStreamTestEventTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(EventStreamTestEventTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EventStreamTestEventTypeEnum value) => value.Value;

    public static explicit operator EventStreamTestEventTypeEnum(string value) => new(value);

    internal class EventStreamTestEventTypeEnumSerializer
        : JsonConverter<EventStreamTestEventTypeEnum>
    {
        public override EventStreamTestEventTypeEnum Read(
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
            return new EventStreamTestEventTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamTestEventTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamTestEventTypeEnum ReadAsPropertyName(
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
            return new EventStreamTestEventTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamTestEventTypeEnum value,
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
