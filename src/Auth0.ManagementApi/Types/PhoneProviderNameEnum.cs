using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(PhoneProviderNameEnum.PhoneProviderNameEnumSerializer))]
[Serializable]
public readonly record struct PhoneProviderNameEnum : IStringEnum
{
    public static readonly PhoneProviderNameEnum Twilio = new(Values.Twilio);

    public static readonly PhoneProviderNameEnum Custom = new(Values.Custom);

    public PhoneProviderNameEnum(string value)
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
    public static PhoneProviderNameEnum FromCustom(string value)
    {
        return new PhoneProviderNameEnum(value);
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

    public static bool operator ==(PhoneProviderNameEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PhoneProviderNameEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PhoneProviderNameEnum value) => value.Value;

    public static explicit operator PhoneProviderNameEnum(string value) => new(value);

    internal class PhoneProviderNameEnumSerializer : JsonConverter<PhoneProviderNameEnum>
    {
        public override PhoneProviderNameEnum Read(
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
            return new PhoneProviderNameEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PhoneProviderNameEnum value,
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
        public const string Twilio = "twilio";

        public const string Custom = "custom";
    }
}
