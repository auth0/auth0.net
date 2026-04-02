using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(GuardianFactorsProviderSmsProviderEnum.GuardianFactorsProviderSmsProviderEnumSerializer)
)]
[Serializable]
public readonly record struct GuardianFactorsProviderSmsProviderEnum : IStringEnum
{
    public static readonly GuardianFactorsProviderSmsProviderEnum Auth0 = new(Values.Auth0);

    public static readonly GuardianFactorsProviderSmsProviderEnum Twilio = new(Values.Twilio);

    public static readonly GuardianFactorsProviderSmsProviderEnum PhoneMessageHook = new(
        Values.PhoneMessageHook
    );

    public GuardianFactorsProviderSmsProviderEnum(string value)
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
    public static GuardianFactorsProviderSmsProviderEnum FromCustom(string value)
    {
        return new GuardianFactorsProviderSmsProviderEnum(value);
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

    public static bool operator ==(GuardianFactorsProviderSmsProviderEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GuardianFactorsProviderSmsProviderEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GuardianFactorsProviderSmsProviderEnum value) =>
        value.Value;

    public static explicit operator GuardianFactorsProviderSmsProviderEnum(string value) =>
        new(value);

    internal class GuardianFactorsProviderSmsProviderEnumSerializer
        : JsonConverter<GuardianFactorsProviderSmsProviderEnum>
    {
        public override GuardianFactorsProviderSmsProviderEnum Read(
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
            return new GuardianFactorsProviderSmsProviderEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GuardianFactorsProviderSmsProviderEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GuardianFactorsProviderSmsProviderEnum ReadAsPropertyName(
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
            return new GuardianFactorsProviderSmsProviderEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GuardianFactorsProviderSmsProviderEnum value,
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

        public const string Twilio = "twilio";

        public const string PhoneMessageHook = "phone-message-hook";
    }
}
