using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventOrgGroupRoleDeletedObjectGroup1TypeEnum.EventStreamCloudEventOrgGroupRoleDeletedObjectGroup1TypeEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventOrgGroupRoleDeletedObjectGroup1TypeEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventOrgGroupRoleDeletedObjectGroup1TypeEnum Organization =
        new(Values.Organization);

    public EventStreamCloudEventOrgGroupRoleDeletedObjectGroup1TypeEnum(string value)
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
    public static EventStreamCloudEventOrgGroupRoleDeletedObjectGroup1TypeEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventOrgGroupRoleDeletedObjectGroup1TypeEnum(value);
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
        EventStreamCloudEventOrgGroupRoleDeletedObjectGroup1TypeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventOrgGroupRoleDeletedObjectGroup1TypeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventOrgGroupRoleDeletedObjectGroup1TypeEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventOrgGroupRoleDeletedObjectGroup1TypeEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventOrgGroupRoleDeletedObjectGroup1TypeEnumSerializer
        : JsonConverter<EventStreamCloudEventOrgGroupRoleDeletedObjectGroup1TypeEnum>
    {
        public override EventStreamCloudEventOrgGroupRoleDeletedObjectGroup1TypeEnum Read(
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
            return new EventStreamCloudEventOrgGroupRoleDeletedObjectGroup1TypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgGroupRoleDeletedObjectGroup1TypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventOrgGroupRoleDeletedObjectGroup1TypeEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventOrgGroupRoleDeletedObjectGroup1TypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgGroupRoleDeletedObjectGroup1TypeEnum value,
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
        public const string Organization = "organization";
    }
}
