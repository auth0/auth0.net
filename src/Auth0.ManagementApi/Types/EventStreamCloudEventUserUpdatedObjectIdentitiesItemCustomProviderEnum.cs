using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventUserUpdatedObjectIdentitiesItemCustomProviderEnum.EventStreamCloudEventUserUpdatedObjectIdentitiesItemCustomProviderEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventUserUpdatedObjectIdentitiesItemCustomProviderEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemCustomProviderEnum Custom =
        new(Values.Custom);

    public EventStreamCloudEventUserUpdatedObjectIdentitiesItemCustomProviderEnum(string value)
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
    public static EventStreamCloudEventUserUpdatedObjectIdentitiesItemCustomProviderEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventUserUpdatedObjectIdentitiesItemCustomProviderEnum(value);
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
        EventStreamCloudEventUserUpdatedObjectIdentitiesItemCustomProviderEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventUserUpdatedObjectIdentitiesItemCustomProviderEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventUserUpdatedObjectIdentitiesItemCustomProviderEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventUserUpdatedObjectIdentitiesItemCustomProviderEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventUserUpdatedObjectIdentitiesItemCustomProviderEnumSerializer
        : JsonConverter<EventStreamCloudEventUserUpdatedObjectIdentitiesItemCustomProviderEnum>
    {
        public override EventStreamCloudEventUserUpdatedObjectIdentitiesItemCustomProviderEnum Read(
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
            return new EventStreamCloudEventUserUpdatedObjectIdentitiesItemCustomProviderEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserUpdatedObjectIdentitiesItemCustomProviderEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventUserUpdatedObjectIdentitiesItemCustomProviderEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventUserUpdatedObjectIdentitiesItemCustomProviderEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserUpdatedObjectIdentitiesItemCustomProviderEnum value,
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
