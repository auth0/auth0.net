using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionDeletedObject2OptionsIdpinitiatedClientProtocolEnum.EventStreamCloudEventConnectionDeletedObject2OptionsIdpinitiatedClientProtocolEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionDeletedObject2OptionsIdpinitiatedClientProtocolEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionDeletedObject2OptionsIdpinitiatedClientProtocolEnum Oidc =
        new(Values.Oidc);

    public static readonly EventStreamCloudEventConnectionDeletedObject2OptionsIdpinitiatedClientProtocolEnum Samlp =
        new(Values.Samlp);

    public static readonly EventStreamCloudEventConnectionDeletedObject2OptionsIdpinitiatedClientProtocolEnum Wsfed =
        new(Values.Wsfed);

    public EventStreamCloudEventConnectionDeletedObject2OptionsIdpinitiatedClientProtocolEnum(
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
    public static EventStreamCloudEventConnectionDeletedObject2OptionsIdpinitiatedClientProtocolEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionDeletedObject2OptionsIdpinitiatedClientProtocolEnum(
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
        EventStreamCloudEventConnectionDeletedObject2OptionsIdpinitiatedClientProtocolEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionDeletedObject2OptionsIdpinitiatedClientProtocolEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionDeletedObject2OptionsIdpinitiatedClientProtocolEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionDeletedObject2OptionsIdpinitiatedClientProtocolEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionDeletedObject2OptionsIdpinitiatedClientProtocolEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionDeletedObject2OptionsIdpinitiatedClientProtocolEnum>
    {
        public override EventStreamCloudEventConnectionDeletedObject2OptionsIdpinitiatedClientProtocolEnum Read(
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
            return new EventStreamCloudEventConnectionDeletedObject2OptionsIdpinitiatedClientProtocolEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionDeletedObject2OptionsIdpinitiatedClientProtocolEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionDeletedObject2OptionsIdpinitiatedClientProtocolEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionDeletedObject2OptionsIdpinitiatedClientProtocolEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionDeletedObject2OptionsIdpinitiatedClientProtocolEnum value,
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
