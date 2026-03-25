using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(TwilioProviderDeliveryMethodEnum.TwilioProviderDeliveryMethodEnumSerializer))]
[Serializable]
public readonly record struct TwilioProviderDeliveryMethodEnum : IStringEnum
{
    public static readonly TwilioProviderDeliveryMethodEnum Text = new(Values.Text);

    public static readonly TwilioProviderDeliveryMethodEnum Voice = new(Values.Voice);

    public TwilioProviderDeliveryMethodEnum(string value)
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
    public static TwilioProviderDeliveryMethodEnum FromCustom(string value)
    {
        return new TwilioProviderDeliveryMethodEnum(value);
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

    public static bool operator ==(TwilioProviderDeliveryMethodEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TwilioProviderDeliveryMethodEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TwilioProviderDeliveryMethodEnum value) => value.Value;

    public static explicit operator TwilioProviderDeliveryMethodEnum(string value) => new(value);

    internal class TwilioProviderDeliveryMethodEnumSerializer
        : JsonConverter<TwilioProviderDeliveryMethodEnum>
    {
        public override TwilioProviderDeliveryMethodEnum Read(
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
            return new TwilioProviderDeliveryMethodEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TwilioProviderDeliveryMethodEnum value,
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
