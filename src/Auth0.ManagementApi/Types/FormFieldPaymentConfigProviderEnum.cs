using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FormFieldPaymentConfigProviderEnum.FormFieldPaymentConfigProviderEnumSerializer)
)]
[Serializable]
public readonly record struct FormFieldPaymentConfigProviderEnum : IStringEnum
{
    public static readonly FormFieldPaymentConfigProviderEnum Stripe = new(Values.Stripe);

    public FormFieldPaymentConfigProviderEnum(string value)
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
    public static FormFieldPaymentConfigProviderEnum FromCustom(string value)
    {
        return new FormFieldPaymentConfigProviderEnum(value);
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

    public static bool operator ==(FormFieldPaymentConfigProviderEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FormFieldPaymentConfigProviderEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FormFieldPaymentConfigProviderEnum value) => value.Value;

    public static explicit operator FormFieldPaymentConfigProviderEnum(string value) => new(value);

    internal class FormFieldPaymentConfigProviderEnumSerializer
        : JsonConverter<FormFieldPaymentConfigProviderEnum>
    {
        public override FormFieldPaymentConfigProviderEnum Read(
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
            return new FormFieldPaymentConfigProviderEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FormFieldPaymentConfigProviderEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FormFieldPaymentConfigProviderEnum ReadAsPropertyName(
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
            return new FormFieldPaymentConfigProviderEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FormFieldPaymentConfigProviderEnum value,
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
        public const string Stripe = "STRIPE";
    }
}
