using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabaseProviderEnum.EventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabaseProviderEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabaseProviderEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabaseProviderEnum Auth0 =
        new(Values.Auth0);

    public EventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabaseProviderEnum(string value)
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
    public static EventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabaseProviderEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabaseProviderEnum(value);
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
        EventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabaseProviderEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabaseProviderEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabaseProviderEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabaseProviderEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabaseProviderEnumSerializer
        : JsonConverter<EventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabaseProviderEnum>
    {
        public override EventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabaseProviderEnum Read(
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
            return new EventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabaseProviderEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabaseProviderEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabaseProviderEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabaseProviderEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabaseProviderEnum value,
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
        public const string Auth0 = "auth0";
    }
}
