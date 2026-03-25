using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(PhoneProviderDeliveryMethodEnum.PhoneProviderDeliveryMethodEnumSerializer))]
[Serializable]
public readonly record struct PhoneProviderDeliveryMethodEnum : IStringEnum
{
    public static readonly PhoneProviderDeliveryMethodEnum Text = new(Values.Text);

    public static readonly PhoneProviderDeliveryMethodEnum Voice = new(Values.Voice);

    public PhoneProviderDeliveryMethodEnum(string value)
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
    public static PhoneProviderDeliveryMethodEnum FromCustom(string value)
    {
        return new PhoneProviderDeliveryMethodEnum(value);
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

    public static bool operator ==(PhoneProviderDeliveryMethodEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PhoneProviderDeliveryMethodEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PhoneProviderDeliveryMethodEnum value) => value.Value;

    public static explicit operator PhoneProviderDeliveryMethodEnum(string value) => new(value);

    internal class PhoneProviderDeliveryMethodEnumSerializer
        : JsonConverter<PhoneProviderDeliveryMethodEnum>
    {
        public override PhoneProviderDeliveryMethodEnum Read(
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
            return new PhoneProviderDeliveryMethodEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PhoneProviderDeliveryMethodEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }
    }

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
