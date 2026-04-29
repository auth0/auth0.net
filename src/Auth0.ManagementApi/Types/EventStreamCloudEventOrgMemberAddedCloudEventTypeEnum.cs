using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventOrgMemberAddedCloudEventTypeEnum.EventStreamCloudEventOrgMemberAddedCloudEventTypeEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventOrgMemberAddedCloudEventTypeEnum : IStringEnum
{
    public static readonly EventStreamCloudEventOrgMemberAddedCloudEventTypeEnum OrganizationMemberAdded =
        new(Values.OrganizationMemberAdded);

    public EventStreamCloudEventOrgMemberAddedCloudEventTypeEnum(string value)
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
    public static EventStreamCloudEventOrgMemberAddedCloudEventTypeEnum FromCustom(string value)
    {
        return new EventStreamCloudEventOrgMemberAddedCloudEventTypeEnum(value);
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
        EventStreamCloudEventOrgMemberAddedCloudEventTypeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventOrgMemberAddedCloudEventTypeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventOrgMemberAddedCloudEventTypeEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventOrgMemberAddedCloudEventTypeEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventOrgMemberAddedCloudEventTypeEnumSerializer
        : JsonConverter<EventStreamCloudEventOrgMemberAddedCloudEventTypeEnum>
    {
        public override EventStreamCloudEventOrgMemberAddedCloudEventTypeEnum Read(
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
            return new EventStreamCloudEventOrgMemberAddedCloudEventTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgMemberAddedCloudEventTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventOrgMemberAddedCloudEventTypeEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventOrgMemberAddedCloudEventTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgMemberAddedCloudEventTypeEnum value,
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
        public const string OrganizationMemberAdded = "organization.member.added";
    }
}
