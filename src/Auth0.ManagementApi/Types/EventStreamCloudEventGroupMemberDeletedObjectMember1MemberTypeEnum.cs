using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventGroupMemberDeletedObjectMember1MemberTypeEnum.EventStreamCloudEventGroupMemberDeletedObjectMember1MemberTypeEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventGroupMemberDeletedObjectMember1MemberTypeEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventGroupMemberDeletedObjectMember1MemberTypeEnum Connection =
        new(Values.Connection);

    public EventStreamCloudEventGroupMemberDeletedObjectMember1MemberTypeEnum(string value)
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
    public static EventStreamCloudEventGroupMemberDeletedObjectMember1MemberTypeEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventGroupMemberDeletedObjectMember1MemberTypeEnum(value);
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
        EventStreamCloudEventGroupMemberDeletedObjectMember1MemberTypeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventGroupMemberDeletedObjectMember1MemberTypeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventGroupMemberDeletedObjectMember1MemberTypeEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventGroupMemberDeletedObjectMember1MemberTypeEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventGroupMemberDeletedObjectMember1MemberTypeEnumSerializer
        : JsonConverter<EventStreamCloudEventGroupMemberDeletedObjectMember1MemberTypeEnum>
    {
        public override EventStreamCloudEventGroupMemberDeletedObjectMember1MemberTypeEnum Read(
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
            return new EventStreamCloudEventGroupMemberDeletedObjectMember1MemberTypeEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupMemberDeletedObjectMember1MemberTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventGroupMemberDeletedObjectMember1MemberTypeEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventGroupMemberDeletedObjectMember1MemberTypeEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupMemberDeletedObjectMember1MemberTypeEnum value,
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
        public const string Connection = "connection";
    }
}
