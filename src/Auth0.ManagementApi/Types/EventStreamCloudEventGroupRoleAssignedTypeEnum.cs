using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventGroupRoleAssignedTypeEnum.EventStreamCloudEventGroupRoleAssignedTypeEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventGroupRoleAssignedTypeEnum : IStringEnum
{
    public static readonly EventStreamCloudEventGroupRoleAssignedTypeEnum GroupRoleAssigned = new(
        Values.GroupRoleAssigned
    );

    public EventStreamCloudEventGroupRoleAssignedTypeEnum(string value)
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
    public static EventStreamCloudEventGroupRoleAssignedTypeEnum FromCustom(string value)
    {
        return new EventStreamCloudEventGroupRoleAssignedTypeEnum(value);
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
        EventStreamCloudEventGroupRoleAssignedTypeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventGroupRoleAssignedTypeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(EventStreamCloudEventGroupRoleAssignedTypeEnum value) =>
        value.Value;

    public static explicit operator EventStreamCloudEventGroupRoleAssignedTypeEnum(string value) =>
        new(value);

    internal class EventStreamCloudEventGroupRoleAssignedTypeEnumSerializer
        : JsonConverter<EventStreamCloudEventGroupRoleAssignedTypeEnum>
    {
        public override EventStreamCloudEventGroupRoleAssignedTypeEnum Read(
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
            return new EventStreamCloudEventGroupRoleAssignedTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupRoleAssignedTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventGroupRoleAssignedTypeEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventGroupRoleAssignedTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupRoleAssignedTypeEnum value,
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
        public const string GroupRoleAssigned = "group.role.assigned";
    }
}
