using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventOrgUpdatedTypeEnum.EventStreamCloudEventOrgUpdatedTypeEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventOrgUpdatedTypeEnum : IStringEnum
{
    public static readonly EventStreamCloudEventOrgUpdatedTypeEnum OrganizationUpdated = new(
        Values.OrganizationUpdated
    );

    public EventStreamCloudEventOrgUpdatedTypeEnum(string value)
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
    public static EventStreamCloudEventOrgUpdatedTypeEnum FromCustom(string value)
    {
        return new EventStreamCloudEventOrgUpdatedTypeEnum(value);
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

    public static bool operator ==(EventStreamCloudEventOrgUpdatedTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(EventStreamCloudEventOrgUpdatedTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EventStreamCloudEventOrgUpdatedTypeEnum value) =>
        value.Value;

    public static explicit operator EventStreamCloudEventOrgUpdatedTypeEnum(string value) =>
        new(value);

    internal class EventStreamCloudEventOrgUpdatedTypeEnumSerializer
        : JsonConverter<EventStreamCloudEventOrgUpdatedTypeEnum>
    {
        public override EventStreamCloudEventOrgUpdatedTypeEnum Read(
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
            return new EventStreamCloudEventOrgUpdatedTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgUpdatedTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventOrgUpdatedTypeEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventOrgUpdatedTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgUpdatedTypeEnum value,
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
        public const string OrganizationUpdated = "organization.updated";
    }
}
