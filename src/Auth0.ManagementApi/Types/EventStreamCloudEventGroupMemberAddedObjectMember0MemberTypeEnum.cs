using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventGroupMemberAddedObjectMember0MemberTypeEnum.EventStreamCloudEventGroupMemberAddedObjectMember0MemberTypeEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventGroupMemberAddedObjectMember0MemberTypeEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventGroupMemberAddedObjectMember0MemberTypeEnum User =
        new(Values.User);

    public EventStreamCloudEventGroupMemberAddedObjectMember0MemberTypeEnum(string value)
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
    public static EventStreamCloudEventGroupMemberAddedObjectMember0MemberTypeEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventGroupMemberAddedObjectMember0MemberTypeEnum(value);
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
        EventStreamCloudEventGroupMemberAddedObjectMember0MemberTypeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventGroupMemberAddedObjectMember0MemberTypeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventGroupMemberAddedObjectMember0MemberTypeEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventGroupMemberAddedObjectMember0MemberTypeEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventGroupMemberAddedObjectMember0MemberTypeEnumSerializer
        : JsonConverter<EventStreamCloudEventGroupMemberAddedObjectMember0MemberTypeEnum>
    {
        public override EventStreamCloudEventGroupMemberAddedObjectMember0MemberTypeEnum Read(
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
            return new EventStreamCloudEventGroupMemberAddedObjectMember0MemberTypeEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupMemberAddedObjectMember0MemberTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventGroupMemberAddedObjectMember0MemberTypeEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventGroupMemberAddedObjectMember0MemberTypeEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupMemberAddedObjectMember0MemberTypeEnum value,
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
        public const string User = "user";
    }
}
