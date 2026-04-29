using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventGroupMemberAddedObjectGroup2TypeEnum.EventStreamCloudEventGroupMemberAddedObjectGroup2TypeEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventGroupMemberAddedObjectGroup2TypeEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventGroupMemberAddedObjectGroup2TypeEnum Tenant = new(
        Values.Tenant
    );

    public EventStreamCloudEventGroupMemberAddedObjectGroup2TypeEnum(string value)
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
    public static EventStreamCloudEventGroupMemberAddedObjectGroup2TypeEnum FromCustom(string value)
    {
        return new EventStreamCloudEventGroupMemberAddedObjectGroup2TypeEnum(value);
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
        EventStreamCloudEventGroupMemberAddedObjectGroup2TypeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventGroupMemberAddedObjectGroup2TypeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventGroupMemberAddedObjectGroup2TypeEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventGroupMemberAddedObjectGroup2TypeEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventGroupMemberAddedObjectGroup2TypeEnumSerializer
        : JsonConverter<EventStreamCloudEventGroupMemberAddedObjectGroup2TypeEnum>
    {
        public override EventStreamCloudEventGroupMemberAddedObjectGroup2TypeEnum Read(
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
            return new EventStreamCloudEventGroupMemberAddedObjectGroup2TypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupMemberAddedObjectGroup2TypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventGroupMemberAddedObjectGroup2TypeEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventGroupMemberAddedObjectGroup2TypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupMemberAddedObjectGroup2TypeEnum value,
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
