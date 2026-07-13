using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionUpdatedObject2OptionsIdpinitiatedClientProtocolEnum.EventStreamCloudEventConnectionUpdatedObject2OptionsIdpinitiatedClientProtocolEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionUpdatedObject2OptionsIdpinitiatedClientProtocolEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionUpdatedObject2OptionsIdpinitiatedClientProtocolEnum Oidc =
        new(Values.Oidc);

    public static readonly EventStreamCloudEventConnectionUpdatedObject2OptionsIdpinitiatedClientProtocolEnum Samlp =
        new(Values.Samlp);

    public static readonly EventStreamCloudEventConnectionUpdatedObject2OptionsIdpinitiatedClientProtocolEnum Wsfed =
        new(Values.Wsfed);

    public EventStreamCloudEventConnectionUpdatedObject2OptionsIdpinitiatedClientProtocolEnum(
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
    public static EventStreamCloudEventConnectionUpdatedObject2OptionsIdpinitiatedClientProtocolEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionUpdatedObject2OptionsIdpinitiatedClientProtocolEnum(
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
        EventStreamCloudEventConnectionUpdatedObject2OptionsIdpinitiatedClientProtocolEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionUpdatedObject2OptionsIdpinitiatedClientProtocolEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionUpdatedObject2OptionsIdpinitiatedClientProtocolEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionUpdatedObject2OptionsIdpinitiatedClientProtocolEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionUpdatedObject2OptionsIdpinitiatedClientProtocolEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionUpdatedObject2OptionsIdpinitiatedClientProtocolEnum>
    {
        public override EventStreamCloudEventConnectionUpdatedObject2OptionsIdpinitiatedClientProtocolEnum Read(
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
            return new EventStreamCloudEventConnectionUpdatedObject2OptionsIdpinitiatedClientProtocolEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionUpdatedObject2OptionsIdpinitiatedClientProtocolEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionUpdatedObject2OptionsIdpinitiatedClientProtocolEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionUpdatedObject2OptionsIdpinitiatedClientProtocolEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionUpdatedObject2OptionsIdpinitiatedClientProtocolEnum value,
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
        public const string Oidc = "oidc";

        public const string Samlp = "samlp";

        public const string Wsfed = "wsfed";
    }
}
