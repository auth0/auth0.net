using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1EnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum
    : IStringEnum
{
    public static readonly EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum Readonly =
        new(Values.Readonly);

    public EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum(
        string value
    )
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
    public static EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum(
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
        EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1EnumSerializer
        : JsonConverter<EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum>
    {
        public override EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum Read(
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
            return new EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum ReadAsPropertyName(
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
            return new EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum value,
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
