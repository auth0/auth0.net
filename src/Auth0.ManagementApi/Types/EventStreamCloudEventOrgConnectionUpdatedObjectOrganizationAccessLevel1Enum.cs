using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1EnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum
    : IStringEnum
{
    public static readonly EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum Readonly =
        new(Values.Readonly);

    public EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum(string value)
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
    public static EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum(
            value
        );
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
        EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1EnumSerializer
        : JsonConverter<EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum>
    {
        public override EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum Read(
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
            return new EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum ReadAsPropertyName(
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
            return new EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum value,
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
        public const string Readonly = "readonly";
    }
}
