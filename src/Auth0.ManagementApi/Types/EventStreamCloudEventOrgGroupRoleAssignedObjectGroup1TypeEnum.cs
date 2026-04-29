using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventOrgGroupRoleAssignedObjectGroup1TypeEnum.EventStreamCloudEventOrgGroupRoleAssignedObjectGroup1TypeEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventOrgGroupRoleAssignedObjectGroup1TypeEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventOrgGroupRoleAssignedObjectGroup1TypeEnum Organization =
        new(Values.Organization);

    public EventStreamCloudEventOrgGroupRoleAssignedObjectGroup1TypeEnum(string value)
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
    public static EventStreamCloudEventOrgGroupRoleAssignedObjectGroup1TypeEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventOrgGroupRoleAssignedObjectGroup1TypeEnum(value);
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
        EventStreamCloudEventOrgGroupRoleAssignedObjectGroup1TypeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventOrgGroupRoleAssignedObjectGroup1TypeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventOrgGroupRoleAssignedObjectGroup1TypeEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventOrgGroupRoleAssignedObjectGroup1TypeEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventOrgGroupRoleAssignedObjectGroup1TypeEnumSerializer
        : JsonConverter<EventStreamCloudEventOrgGroupRoleAssignedObjectGroup1TypeEnum>
    {
        public override EventStreamCloudEventOrgGroupRoleAssignedObjectGroup1TypeEnum Read(
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
            return new EventStreamCloudEventOrgGroupRoleAssignedObjectGroup1TypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgGroupRoleAssignedObjectGroup1TypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventOrgGroupRoleAssignedObjectGroup1TypeEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventOrgGroupRoleAssignedObjectGroup1TypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgGroupRoleAssignedObjectGroup1TypeEnum value,
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
