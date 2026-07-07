using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionDeletedObject2OptionsProtocolBindingEnum.EventStreamCloudEventConnectionDeletedObject2OptionsProtocolBindingEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionDeletedObject2OptionsProtocolBindingEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionDeletedObject2OptionsProtocolBindingEnum UrnOasisNamesTcSaml20BindingsHttpPost =
        new(Values.UrnOasisNamesTcSaml20BindingsHttpPost);

    public static readonly EventStreamCloudEventConnectionDeletedObject2OptionsProtocolBindingEnum UrnOasisNamesTcSaml20BindingsHttpRedirect =
        new(Values.UrnOasisNamesTcSaml20BindingsHttpRedirect);

    public EventStreamCloudEventConnectionDeletedObject2OptionsProtocolBindingEnum(string value)
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
    public static EventStreamCloudEventConnectionDeletedObject2OptionsProtocolBindingEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionDeletedObject2OptionsProtocolBindingEnum(value);
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
        EventStreamCloudEventConnectionDeletedObject2OptionsProtocolBindingEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionDeletedObject2OptionsProtocolBindingEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionDeletedObject2OptionsProtocolBindingEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionDeletedObject2OptionsProtocolBindingEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionDeletedObject2OptionsProtocolBindingEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionDeletedObject2OptionsProtocolBindingEnum>
    {
        public override EventStreamCloudEventConnectionDeletedObject2OptionsProtocolBindingEnum Read(
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
            return new EventStreamCloudEventConnectionDeletedObject2OptionsProtocolBindingEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionDeletedObject2OptionsProtocolBindingEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionDeletedObject2OptionsProtocolBindingEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionDeletedObject2OptionsProtocolBindingEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionDeletedObject2OptionsProtocolBindingEnum value,
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
        public const string UrnOasisNamesTcSaml20BindingsHttpPost =
            "urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST";

        public const string UrnOasisNamesTcSaml20BindingsHttpRedirect =
            "urn:oasis:names:tc:SAML:2.0:bindings:HTTP-Redirect";
    }
}
