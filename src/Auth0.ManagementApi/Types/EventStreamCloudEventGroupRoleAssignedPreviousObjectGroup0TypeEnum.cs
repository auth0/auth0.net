using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0TypeEnum.EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0TypeEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0TypeEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0TypeEnum Connection =
        new(Values.Connection);

    public EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0TypeEnum(string value)
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
    public static EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0TypeEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0TypeEnum(value);
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
        EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0TypeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0TypeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0TypeEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0TypeEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0TypeEnumSerializer
        : JsonConverter<EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0TypeEnum>
    {
        public override EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0TypeEnum Read(
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
            return new EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0TypeEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0TypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0TypeEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0TypeEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0TypeEnum value,
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
        public const string Connection = "connection";
    }
}
