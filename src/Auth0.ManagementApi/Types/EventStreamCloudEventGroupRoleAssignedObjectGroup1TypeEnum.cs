using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventGroupRoleAssignedObjectGroup1TypeEnum.EventStreamCloudEventGroupRoleAssignedObjectGroup1TypeEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventGroupRoleAssignedObjectGroup1TypeEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventGroupRoleAssignedObjectGroup1TypeEnum Organization =
        new(Values.Organization);

    public EventStreamCloudEventGroupRoleAssignedObjectGroup1TypeEnum(string value)
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
    public static EventStreamCloudEventGroupRoleAssignedObjectGroup1TypeEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventGroupRoleAssignedObjectGroup1TypeEnum(value);
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
        EventStreamCloudEventGroupRoleAssignedObjectGroup1TypeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventGroupRoleAssignedObjectGroup1TypeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventGroupRoleAssignedObjectGroup1TypeEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventGroupRoleAssignedObjectGroup1TypeEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventGroupRoleAssignedObjectGroup1TypeEnumSerializer
        : JsonConverter<EventStreamCloudEventGroupRoleAssignedObjectGroup1TypeEnum>
    {
        public override EventStreamCloudEventGroupRoleAssignedObjectGroup1TypeEnum Read(
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
            return new EventStreamCloudEventGroupRoleAssignedObjectGroup1TypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupRoleAssignedObjectGroup1TypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventGroupRoleAssignedObjectGroup1TypeEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventGroupRoleAssignedObjectGroup1TypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupRoleAssignedObjectGroup1TypeEnum value,
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
