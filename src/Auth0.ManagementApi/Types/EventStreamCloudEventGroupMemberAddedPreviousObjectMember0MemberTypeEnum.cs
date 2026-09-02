using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventGroupMemberAddedPreviousObjectMember0MemberTypeEnum.EventStreamCloudEventGroupMemberAddedPreviousObjectMember0MemberTypeEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventGroupMemberAddedPreviousObjectMember0MemberTypeEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventGroupMemberAddedPreviousObjectMember0MemberTypeEnum User =
        new(Values.User);

    public EventStreamCloudEventGroupMemberAddedPreviousObjectMember0MemberTypeEnum(string value)
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
    public static EventStreamCloudEventGroupMemberAddedPreviousObjectMember0MemberTypeEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventGroupMemberAddedPreviousObjectMember0MemberTypeEnum(value);
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
        EventStreamCloudEventGroupMemberAddedPreviousObjectMember0MemberTypeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventGroupMemberAddedPreviousObjectMember0MemberTypeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventGroupMemberAddedPreviousObjectMember0MemberTypeEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventGroupMemberAddedPreviousObjectMember0MemberTypeEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventGroupMemberAddedPreviousObjectMember0MemberTypeEnumSerializer
        : JsonConverter<EventStreamCloudEventGroupMemberAddedPreviousObjectMember0MemberTypeEnum>
    {
        public override EventStreamCloudEventGroupMemberAddedPreviousObjectMember0MemberTypeEnum Read(
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
            return new EventStreamCloudEventGroupMemberAddedPreviousObjectMember0MemberTypeEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupMemberAddedPreviousObjectMember0MemberTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventGroupMemberAddedPreviousObjectMember0MemberTypeEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventGroupMemberAddedPreviousObjectMember0MemberTypeEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupMemberAddedPreviousObjectMember0MemberTypeEnum value,
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
