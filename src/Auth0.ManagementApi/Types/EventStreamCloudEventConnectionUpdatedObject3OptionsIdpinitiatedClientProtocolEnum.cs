using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionUpdatedObject3OptionsIdpinitiatedClientProtocolEnum.EventStreamCloudEventConnectionUpdatedObject3OptionsIdpinitiatedClientProtocolEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionUpdatedObject3OptionsIdpinitiatedClientProtocolEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionUpdatedObject3OptionsIdpinitiatedClientProtocolEnum Oidc =
        new(Values.Oidc);

    public static readonly EventStreamCloudEventConnectionUpdatedObject3OptionsIdpinitiatedClientProtocolEnum Samlp =
        new(Values.Samlp);

    public static readonly EventStreamCloudEventConnectionUpdatedObject3OptionsIdpinitiatedClientProtocolEnum Wsfed =
        new(Values.Wsfed);

    public EventStreamCloudEventConnectionUpdatedObject3OptionsIdpinitiatedClientProtocolEnum(
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
    public static EventStreamCloudEventConnectionUpdatedObject3OptionsIdpinitiatedClientProtocolEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionUpdatedObject3OptionsIdpinitiatedClientProtocolEnum(
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
        EventStreamCloudEventConnectionUpdatedObject3OptionsIdpinitiatedClientProtocolEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionUpdatedObject3OptionsIdpinitiatedClientProtocolEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionUpdatedObject3OptionsIdpinitiatedClientProtocolEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionUpdatedObject3OptionsIdpinitiatedClientProtocolEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionUpdatedObject3OptionsIdpinitiatedClientProtocolEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionUpdatedObject3OptionsIdpinitiatedClientProtocolEnum>
    {
        public override EventStreamCloudEventConnectionUpdatedObject3OptionsIdpinitiatedClientProtocolEnum Read(
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
            return new EventStreamCloudEventConnectionUpdatedObject3OptionsIdpinitiatedClientProtocolEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionUpdatedObject3OptionsIdpinitiatedClientProtocolEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionUpdatedObject3OptionsIdpinitiatedClientProtocolEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionUpdatedObject3OptionsIdpinitiatedClientProtocolEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionUpdatedObject3OptionsIdpinitiatedClientProtocolEnum value,
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
