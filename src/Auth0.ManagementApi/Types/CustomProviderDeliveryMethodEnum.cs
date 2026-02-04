using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<CustomProviderDeliveryMethodEnum>))]
[Serializable]
public readonly record struct CustomProviderDeliveryMethodEnum : IStringEnum
{
    public static readonly CustomProviderDeliveryMethodEnum Text = new(Values.Text);

    public static readonly CustomProviderDeliveryMethodEnum Voice = new(Values.Voice);

    public CustomProviderDeliveryMethodEnum(string value)
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
    public static CustomProviderDeliveryMethodEnum FromCustom(string value)
    {
        return new CustomProviderDeliveryMethodEnum(value);
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

    public static bool operator ==(CustomProviderDeliveryMethodEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CustomProviderDeliveryMethodEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CustomProviderDeliveryMethodEnum value) => value.Value;

    public static explicit operator CustomProviderDeliveryMethodEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Text = "text";

        public const string Voice = "voice";
    }
}
