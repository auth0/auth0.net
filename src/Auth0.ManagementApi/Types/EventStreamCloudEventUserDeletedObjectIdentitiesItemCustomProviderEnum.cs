using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventUserDeletedObjectIdentitiesItemCustomProviderEnum.EventStreamCloudEventUserDeletedObjectIdentitiesItemCustomProviderEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventUserDeletedObjectIdentitiesItemCustomProviderEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemCustomProviderEnum Custom =
        new(Values.Custom);

    public EventStreamCloudEventUserDeletedObjectIdentitiesItemCustomProviderEnum(string value)
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
    public static EventStreamCloudEventUserDeletedObjectIdentitiesItemCustomProviderEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventUserDeletedObjectIdentitiesItemCustomProviderEnum(value);
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
        EventStreamCloudEventUserDeletedObjectIdentitiesItemCustomProviderEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventUserDeletedObjectIdentitiesItemCustomProviderEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventUserDeletedObjectIdentitiesItemCustomProviderEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventUserDeletedObjectIdentitiesItemCustomProviderEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventUserDeletedObjectIdentitiesItemCustomProviderEnumSerializer
        : JsonConverter<EventStreamCloudEventUserDeletedObjectIdentitiesItemCustomProviderEnum>
    {
        public override EventStreamCloudEventUserDeletedObjectIdentitiesItemCustomProviderEnum Read(
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
            return new EventStreamCloudEventUserDeletedObjectIdentitiesItemCustomProviderEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserDeletedObjectIdentitiesItemCustomProviderEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventUserDeletedObjectIdentitiesItemCustomProviderEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventUserDeletedObjectIdentitiesItemCustomProviderEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserDeletedObjectIdentitiesItemCustomProviderEnum value,
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
        public const string Custom = "custom";
    }
}
