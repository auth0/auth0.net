using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2TypeEnum.EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2TypeEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2TypeEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2TypeEnum Tenant =
        new(Values.Tenant);

    public EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2TypeEnum(string value)
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
    public static EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2TypeEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2TypeEnum(value);
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
        EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2TypeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2TypeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2TypeEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2TypeEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2TypeEnumSerializer
        : JsonConverter<EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2TypeEnum>
    {
        public override EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2TypeEnum Read(
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
            return new EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2TypeEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2TypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2TypeEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2TypeEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2TypeEnum value,
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
