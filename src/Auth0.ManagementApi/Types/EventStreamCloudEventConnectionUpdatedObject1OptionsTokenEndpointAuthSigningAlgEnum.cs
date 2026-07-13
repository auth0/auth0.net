using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionUpdatedObject1OptionsTokenEndpointAuthSigningAlgEnum.EventStreamCloudEventConnectionUpdatedObject1OptionsTokenEndpointAuthSigningAlgEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionUpdatedObject1OptionsTokenEndpointAuthSigningAlgEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionUpdatedObject1OptionsTokenEndpointAuthSigningAlgEnum Es256 =
        new(Values.Es256);

    public static readonly EventStreamCloudEventConnectionUpdatedObject1OptionsTokenEndpointAuthSigningAlgEnum Es384 =
        new(Values.Es384);

    public static readonly EventStreamCloudEventConnectionUpdatedObject1OptionsTokenEndpointAuthSigningAlgEnum Ps256 =
        new(Values.Ps256);

    public static readonly EventStreamCloudEventConnectionUpdatedObject1OptionsTokenEndpointAuthSigningAlgEnum Ps384 =
        new(Values.Ps384);

    public static readonly EventStreamCloudEventConnectionUpdatedObject1OptionsTokenEndpointAuthSigningAlgEnum Rs256 =
        new(Values.Rs256);

    public static readonly EventStreamCloudEventConnectionUpdatedObject1OptionsTokenEndpointAuthSigningAlgEnum Rs384 =
        new(Values.Rs384);

    public static readonly EventStreamCloudEventConnectionUpdatedObject1OptionsTokenEndpointAuthSigningAlgEnum Rs512 =
        new(Values.Rs512);

    public EventStreamCloudEventConnectionUpdatedObject1OptionsTokenEndpointAuthSigningAlgEnum(
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
    public static EventStreamCloudEventConnectionUpdatedObject1OptionsTokenEndpointAuthSigningAlgEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionUpdatedObject1OptionsTokenEndpointAuthSigningAlgEnum(
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
        EventStreamCloudEventConnectionUpdatedObject1OptionsTokenEndpointAuthSigningAlgEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionUpdatedObject1OptionsTokenEndpointAuthSigningAlgEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionUpdatedObject1OptionsTokenEndpointAuthSigningAlgEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionUpdatedObject1OptionsTokenEndpointAuthSigningAlgEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionUpdatedObject1OptionsTokenEndpointAuthSigningAlgEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionUpdatedObject1OptionsTokenEndpointAuthSigningAlgEnum>
    {
        public override EventStreamCloudEventConnectionUpdatedObject1OptionsTokenEndpointAuthSigningAlgEnum Read(
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
            return new EventStreamCloudEventConnectionUpdatedObject1OptionsTokenEndpointAuthSigningAlgEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionUpdatedObject1OptionsTokenEndpointAuthSigningAlgEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionUpdatedObject1OptionsTokenEndpointAuthSigningAlgEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionUpdatedObject1OptionsTokenEndpointAuthSigningAlgEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionUpdatedObject1OptionsTokenEndpointAuthSigningAlgEnum value,
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
