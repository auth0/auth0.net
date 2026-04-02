using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FormFieldPaymentConfigChargeOneOffCurrencyEnum.FormFieldPaymentConfigChargeOneOffCurrencyEnumSerializer)
)]
[Serializable]
public readonly record struct FormFieldPaymentConfigChargeOneOffCurrencyEnum : IStringEnum
{
    public static readonly FormFieldPaymentConfigChargeOneOffCurrencyEnum Aud = new(Values.Aud);

    public static readonly FormFieldPaymentConfigChargeOneOffCurrencyEnum Cad = new(Values.Cad);

    public static readonly FormFieldPaymentConfigChargeOneOffCurrencyEnum Chf = new(Values.Chf);

    public static readonly FormFieldPaymentConfigChargeOneOffCurrencyEnum Eur = new(Values.Eur);

    public static readonly FormFieldPaymentConfigChargeOneOffCurrencyEnum Gbp = new(Values.Gbp);

    public static readonly FormFieldPaymentConfigChargeOneOffCurrencyEnum Inr = new(Values.Inr);

    public static readonly FormFieldPaymentConfigChargeOneOffCurrencyEnum Mxn = new(Values.Mxn);

    public static readonly FormFieldPaymentConfigChargeOneOffCurrencyEnum Sek = new(Values.Sek);

    public static readonly FormFieldPaymentConfigChargeOneOffCurrencyEnum Usd = new(Values.Usd);

    public FormFieldPaymentConfigChargeOneOffCurrencyEnum(string value)
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
    public static FormFieldPaymentConfigChargeOneOffCurrencyEnum FromCustom(string value)
    {
        return new FormFieldPaymentConfigChargeOneOffCurrencyEnum(value);
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
        FormFieldPaymentConfigChargeOneOffCurrencyEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        FormFieldPaymentConfigChargeOneOffCurrencyEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(FormFieldPaymentConfigChargeOneOffCurrencyEnum value) =>
        value.Value;

    public static explicit operator FormFieldPaymentConfigChargeOneOffCurrencyEnum(string value) =>
        new(value);

    internal class FormFieldPaymentConfigChargeOneOffCurrencyEnumSerializer
        : JsonConverter<FormFieldPaymentConfigChargeOneOffCurrencyEnum>
    {
        public override FormFieldPaymentConfigChargeOneOffCurrencyEnum Read(
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
            return new FormFieldPaymentConfigChargeOneOffCurrencyEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FormFieldPaymentConfigChargeOneOffCurrencyEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FormFieldPaymentConfigChargeOneOffCurrencyEnum ReadAsPropertyName(
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
            return new FormFieldPaymentConfigChargeOneOffCurrencyEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FormFieldPaymentConfigChargeOneOffCurrencyEnum value,
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
        public const string Aud = "AUD";

        public const string Cad = "CAD";

        public const string Chf = "CHF";

        public const string Eur = "EUR";

        public const string Gbp = "GBP";

        public const string Inr = "INR";

        public const string Mxn = "MXN";

        public const string Sek = "SEK";

        public const string Usd = "USD";
    }
}
