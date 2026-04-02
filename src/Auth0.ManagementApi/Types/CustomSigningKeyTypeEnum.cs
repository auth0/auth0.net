using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(CustomSigningKeyTypeEnum.CustomSigningKeyTypeEnumSerializer))]
[Serializable]
public readonly record struct CustomSigningKeyTypeEnum : IStringEnum
{
    public static readonly CustomSigningKeyTypeEnum Ec = new(Values.Ec);

    public static readonly CustomSigningKeyTypeEnum Rsa = new(Values.Rsa);

    public CustomSigningKeyTypeEnum(string value)
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
    public static CustomSigningKeyTypeEnum FromCustom(string value)
    {
        return new CustomSigningKeyTypeEnum(value);
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

    public static bool operator ==(CustomSigningKeyTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CustomSigningKeyTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CustomSigningKeyTypeEnum value) => value.Value;

    public static explicit operator CustomSigningKeyTypeEnum(string value) => new(value);

    internal class CustomSigningKeyTypeEnumSerializer : JsonConverter<CustomSigningKeyTypeEnum>
    {
        public override CustomSigningKeyTypeEnum Read(
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
            return new CustomSigningKeyTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CustomSigningKeyTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CustomSigningKeyTypeEnum ReadAsPropertyName(
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
            return new CustomSigningKeyTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CustomSigningKeyTypeEnum value,
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
        public const string Ec = "EC";

        public const string Rsa = "RSA";
    }
}
