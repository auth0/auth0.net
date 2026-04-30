using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventGroupMemberAddedTypeEnum.EventStreamCloudEventGroupMemberAddedTypeEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventGroupMemberAddedTypeEnum : IStringEnum
{
    public static readonly EventStreamCloudEventGroupMemberAddedTypeEnum GroupMemberAdded = new(
        Values.GroupMemberAdded
    );

    public EventStreamCloudEventGroupMemberAddedTypeEnum(string value)
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
    public static EventStreamCloudEventGroupMemberAddedTypeEnum FromCustom(string value)
    {
        return new EventStreamCloudEventGroupMemberAddedTypeEnum(value);
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
        EventStreamCloudEventGroupMemberAddedTypeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventGroupMemberAddedTypeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(EventStreamCloudEventGroupMemberAddedTypeEnum value) =>
        value.Value;

    public static explicit operator EventStreamCloudEventGroupMemberAddedTypeEnum(string value) =>
        new(value);

    internal class EventStreamCloudEventGroupMemberAddedTypeEnumSerializer
        : JsonConverter<EventStreamCloudEventGroupMemberAddedTypeEnum>
    {
        public override EventStreamCloudEventGroupMemberAddedTypeEnum Read(
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
            return new EventStreamCloudEventGroupMemberAddedTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupMemberAddedTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventGroupMemberAddedTypeEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventGroupMemberAddedTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupMemberAddedTypeEnum value,
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
        public const string GroupMemberAdded = "group.member.added";
    }
}
