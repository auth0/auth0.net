using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventGroupMemberDeletedCloudEventTypeEnum.EventStreamCloudEventGroupMemberDeletedCloudEventTypeEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventGroupMemberDeletedCloudEventTypeEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventGroupMemberDeletedCloudEventTypeEnum GroupMemberDeleted =
        new(Values.GroupMemberDeleted);

    public EventStreamCloudEventGroupMemberDeletedCloudEventTypeEnum(string value)
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
    public static EventStreamCloudEventGroupMemberDeletedCloudEventTypeEnum FromCustom(string value)
    {
        return new EventStreamCloudEventGroupMemberDeletedCloudEventTypeEnum(value);
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
        EventStreamCloudEventGroupMemberDeletedCloudEventTypeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventGroupMemberDeletedCloudEventTypeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventGroupMemberDeletedCloudEventTypeEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventGroupMemberDeletedCloudEventTypeEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventGroupMemberDeletedCloudEventTypeEnumSerializer
        : JsonConverter<EventStreamCloudEventGroupMemberDeletedCloudEventTypeEnum>
    {
        public override EventStreamCloudEventGroupMemberDeletedCloudEventTypeEnum Read(
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
            return new EventStreamCloudEventGroupMemberDeletedCloudEventTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupMemberDeletedCloudEventTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventGroupMemberDeletedCloudEventTypeEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventGroupMemberDeletedCloudEventTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupMemberDeletedCloudEventTypeEnum value,
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
        public const string GroupMemberDeleted = "group.member.deleted";
    }
}
