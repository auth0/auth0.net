using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FormFieldPaymentConfigChargeOneOffCurrencyEnum>))]
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
