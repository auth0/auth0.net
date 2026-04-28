using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventUserCreatedObjectIdentitiesItemDatabaseProviderEnum.EventStreamCloudEventUserCreatedObjectIdentitiesItemDatabaseProviderEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventUserCreatedObjectIdentitiesItemDatabaseProviderEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemDatabaseProviderEnum Auth0 =
        new(Values.Auth0);

    public EventStreamCloudEventUserCreatedObjectIdentitiesItemDatabaseProviderEnum(string value)
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
    public static EventStreamCloudEventUserCreatedObjectIdentitiesItemDatabaseProviderEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventUserCreatedObjectIdentitiesItemDatabaseProviderEnum(value);
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
        EventStreamCloudEventUserCreatedObjectIdentitiesItemDatabaseProviderEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventUserCreatedObjectIdentitiesItemDatabaseProviderEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventUserCreatedObjectIdentitiesItemDatabaseProviderEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventUserCreatedObjectIdentitiesItemDatabaseProviderEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventUserCreatedObjectIdentitiesItemDatabaseProviderEnumSerializer
        : JsonConverter<EventStreamCloudEventUserCreatedObjectIdentitiesItemDatabaseProviderEnum>
    {
        public override EventStreamCloudEventUserCreatedObjectIdentitiesItemDatabaseProviderEnum Read(
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
            return new EventStreamCloudEventUserCreatedObjectIdentitiesItemDatabaseProviderEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserCreatedObjectIdentitiesItemDatabaseProviderEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventUserCreatedObjectIdentitiesItemDatabaseProviderEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventUserCreatedObjectIdentitiesItemDatabaseProviderEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserCreatedObjectIdentitiesItemDatabaseProviderEnum value,
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
