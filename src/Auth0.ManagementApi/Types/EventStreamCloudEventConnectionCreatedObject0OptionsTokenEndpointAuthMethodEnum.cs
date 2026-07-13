using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthMethodEnum.EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthMethodEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthMethodEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthMethodEnum ClientSecretPost =
        new(Values.ClientSecretPost);

    public static readonly EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthMethodEnum PrivateKeyJwt =
        new(Values.PrivateKeyJwt);

    public EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthMethodEnum(
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
    public static EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthMethodEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthMethodEnum(
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
        EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthMethodEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthMethodEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthMethodEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthMethodEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthMethodEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthMethodEnum>
    {
        public override EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthMethodEnum Read(
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
            return new EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthMethodEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthMethodEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthMethodEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthMethodEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthMethodEnum value,
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
