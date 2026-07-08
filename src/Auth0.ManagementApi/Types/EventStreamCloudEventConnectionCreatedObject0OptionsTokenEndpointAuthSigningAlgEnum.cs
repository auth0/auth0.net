using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthSigningAlgEnum.EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthSigningAlgEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthSigningAlgEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthSigningAlgEnum Es256 =
        new(Values.Es256);

    public static readonly EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthSigningAlgEnum Es384 =
        new(Values.Es384);

    public static readonly EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthSigningAlgEnum Ps256 =
        new(Values.Ps256);

    public static readonly EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthSigningAlgEnum Ps384 =
        new(Values.Ps384);

    public static readonly EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthSigningAlgEnum Rs256 =
        new(Values.Rs256);

    public static readonly EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthSigningAlgEnum Rs384 =
        new(Values.Rs384);

    public static readonly EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthSigningAlgEnum Rs512 =
        new(Values.Rs512);

    public EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthSigningAlgEnum(
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
    public static EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthSigningAlgEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthSigningAlgEnum(
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
        EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthSigningAlgEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthSigningAlgEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthSigningAlgEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthSigningAlgEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthSigningAlgEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthSigningAlgEnum>
    {
        public override EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthSigningAlgEnum Read(
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
            return new EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthSigningAlgEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthSigningAlgEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthSigningAlgEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthSigningAlgEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointAuthSigningAlgEnum value,
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
        public const string Es256 = "ES256";

        public const string Es384 = "ES384";

        public const string Ps256 = "PS256";

        public const string Ps384 = "PS384";

        public const string Rs256 = "RS256";

        public const string Rs384 = "RS384";

        public const string Rs512 = "RS512";
    }
}
