using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionDeletedObject0OptionsTokenEndpointAuthMethodEnum.EventStreamCloudEventConnectionDeletedObject0OptionsTokenEndpointAuthMethodEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionDeletedObject0OptionsTokenEndpointAuthMethodEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionDeletedObject0OptionsTokenEndpointAuthMethodEnum ClientSecretPost =
        new(Values.ClientSecretPost);

    public static readonly EventStreamCloudEventConnectionDeletedObject0OptionsTokenEndpointAuthMethodEnum PrivateKeyJwt =
        new(Values.PrivateKeyJwt);

    public EventStreamCloudEventConnectionDeletedObject0OptionsTokenEndpointAuthMethodEnum(
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
    public static EventStreamCloudEventConnectionDeletedObject0OptionsTokenEndpointAuthMethodEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionDeletedObject0OptionsTokenEndpointAuthMethodEnum(
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
        EventStreamCloudEventConnectionDeletedObject0OptionsTokenEndpointAuthMethodEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionDeletedObject0OptionsTokenEndpointAuthMethodEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionDeletedObject0OptionsTokenEndpointAuthMethodEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionDeletedObject0OptionsTokenEndpointAuthMethodEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionDeletedObject0OptionsTokenEndpointAuthMethodEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionDeletedObject0OptionsTokenEndpointAuthMethodEnum>
    {
        public override EventStreamCloudEventConnectionDeletedObject0OptionsTokenEndpointAuthMethodEnum Read(
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
            return new EventStreamCloudEventConnectionDeletedObject0OptionsTokenEndpointAuthMethodEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionDeletedObject0OptionsTokenEndpointAuthMethodEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionDeletedObject0OptionsTokenEndpointAuthMethodEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionDeletedObject0OptionsTokenEndpointAuthMethodEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionDeletedObject0OptionsTokenEndpointAuthMethodEnum value,
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
        public const string ClientSecretPost = "client_secret_post";

        public const string PrivateKeyJwt = "private_key_jwt";
    }
}
