using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventGroupRoleDeletedObjectGroup2TypeEnum.EventStreamCloudEventGroupRoleDeletedObjectGroup2TypeEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventGroupRoleDeletedObjectGroup2TypeEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventGroupRoleDeletedObjectGroup2TypeEnum Tenant = new(
        Values.Tenant
    );

    public EventStreamCloudEventGroupRoleDeletedObjectGroup2TypeEnum(string value)
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
    public static EventStreamCloudEventGroupRoleDeletedObjectGroup2TypeEnum FromCustom(string value)
    {
        return new EventStreamCloudEventGroupRoleDeletedObjectGroup2TypeEnum(value);
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
        EventStreamCloudEventGroupRoleDeletedObjectGroup2TypeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventGroupRoleDeletedObjectGroup2TypeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventGroupRoleDeletedObjectGroup2TypeEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventGroupRoleDeletedObjectGroup2TypeEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventGroupRoleDeletedObjectGroup2TypeEnumSerializer
        : JsonConverter<EventStreamCloudEventGroupRoleDeletedObjectGroup2TypeEnum>
    {
        public override EventStreamCloudEventGroupRoleDeletedObjectGroup2TypeEnum Read(
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
            return new EventStreamCloudEventGroupRoleDeletedObjectGroup2TypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupRoleDeletedObjectGroup2TypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventGroupRoleDeletedObjectGroup2TypeEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventGroupRoleDeletedObjectGroup2TypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupRoleDeletedObjectGroup2TypeEnum value,
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
        public const string Tenant = "tenant";
    }
}
