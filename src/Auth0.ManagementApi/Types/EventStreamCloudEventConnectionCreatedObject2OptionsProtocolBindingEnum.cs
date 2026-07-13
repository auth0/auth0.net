using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionCreatedObject2OptionsProtocolBindingEnum.EventStreamCloudEventConnectionCreatedObject2OptionsProtocolBindingEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionCreatedObject2OptionsProtocolBindingEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionCreatedObject2OptionsProtocolBindingEnum UrnOasisNamesTcSaml20BindingsHttpPost =
        new(Values.UrnOasisNamesTcSaml20BindingsHttpPost);

    public static readonly EventStreamCloudEventConnectionCreatedObject2OptionsProtocolBindingEnum UrnOasisNamesTcSaml20BindingsHttpRedirect =
        new(Values.UrnOasisNamesTcSaml20BindingsHttpRedirect);

    public EventStreamCloudEventConnectionCreatedObject2OptionsProtocolBindingEnum(string value)
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
    public static EventStreamCloudEventConnectionCreatedObject2OptionsProtocolBindingEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionCreatedObject2OptionsProtocolBindingEnum(value);
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
        EventStreamCloudEventConnectionCreatedObject2OptionsProtocolBindingEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionCreatedObject2OptionsProtocolBindingEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionCreatedObject2OptionsProtocolBindingEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionCreatedObject2OptionsProtocolBindingEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionCreatedObject2OptionsProtocolBindingEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionCreatedObject2OptionsProtocolBindingEnum>
    {
        public override EventStreamCloudEventConnectionCreatedObject2OptionsProtocolBindingEnum Read(
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
            return new EventStreamCloudEventConnectionCreatedObject2OptionsProtocolBindingEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedObject2OptionsProtocolBindingEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionCreatedObject2OptionsProtocolBindingEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionCreatedObject2OptionsProtocolBindingEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedObject2OptionsProtocolBindingEnum value,
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
