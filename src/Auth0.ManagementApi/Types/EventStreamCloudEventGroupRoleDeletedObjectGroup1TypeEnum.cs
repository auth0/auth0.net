using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventGroupRoleDeletedObjectGroup1TypeEnum.EventStreamCloudEventGroupRoleDeletedObjectGroup1TypeEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventGroupRoleDeletedObjectGroup1TypeEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventGroupRoleDeletedObjectGroup1TypeEnum Organization =
        new(Values.Organization);

    public EventStreamCloudEventGroupRoleDeletedObjectGroup1TypeEnum(string value)
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
    public static EventStreamCloudEventGroupRoleDeletedObjectGroup1TypeEnum FromCustom(string value)
    {
        return new EventStreamCloudEventGroupRoleDeletedObjectGroup1TypeEnum(value);
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
        EventStreamCloudEventGroupRoleDeletedObjectGroup1TypeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventGroupRoleDeletedObjectGroup1TypeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventGroupRoleDeletedObjectGroup1TypeEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventGroupRoleDeletedObjectGroup1TypeEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventGroupRoleDeletedObjectGroup1TypeEnumSerializer
        : JsonConverter<EventStreamCloudEventGroupRoleDeletedObjectGroup1TypeEnum>
    {
        public override EventStreamCloudEventGroupRoleDeletedObjectGroup1TypeEnum Read(
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
            return new EventStreamCloudEventGroupRoleDeletedObjectGroup1TypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupRoleDeletedObjectGroup1TypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventGroupRoleDeletedObjectGroup1TypeEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventGroupRoleDeletedObjectGroup1TypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupRoleDeletedObjectGroup1TypeEnum value,
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
