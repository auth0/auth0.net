using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(CustomSigningKeyAlgorithmEnum.CustomSigningKeyAlgorithmEnumSerializer))]
[Serializable]
public readonly record struct CustomSigningKeyAlgorithmEnum : IStringEnum
{
    public static readonly CustomSigningKeyAlgorithmEnum Rs256 = new(Values.Rs256);

    public static readonly CustomSigningKeyAlgorithmEnum Rs384 = new(Values.Rs384);

    public static readonly CustomSigningKeyAlgorithmEnum Rs512 = new(Values.Rs512);

    public static readonly CustomSigningKeyAlgorithmEnum Es256 = new(Values.Es256);

    public static readonly CustomSigningKeyAlgorithmEnum Es384 = new(Values.Es384);

    public static readonly CustomSigningKeyAlgorithmEnum Es512 = new(Values.Es512);

    public static readonly CustomSigningKeyAlgorithmEnum Ps256 = new(Values.Ps256);

    public static readonly CustomSigningKeyAlgorithmEnum Ps384 = new(Values.Ps384);

    public static readonly CustomSigningKeyAlgorithmEnum Ps512 = new(Values.Ps512);

    public CustomSigningKeyAlgorithmEnum(string value)
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
    public static CustomSigningKeyAlgorithmEnum FromCustom(string value)
    {
        return new CustomSigningKeyAlgorithmEnum(value);
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

    public static bool operator ==(CustomSigningKeyAlgorithmEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CustomSigningKeyAlgorithmEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CustomSigningKeyAlgorithmEnum value) => value.Value;

    public static explicit operator CustomSigningKeyAlgorithmEnum(string value) => new(value);

    internal class CustomSigningKeyAlgorithmEnumSerializer
        : JsonConverter<CustomSigningKeyAlgorithmEnum>
    {
        public override CustomSigningKeyAlgorithmEnum Read(
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
            return new CustomSigningKeyAlgorithmEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CustomSigningKeyAlgorithmEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CustomSigningKeyAlgorithmEnum ReadAsPropertyName(
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
            return new CustomSigningKeyAlgorithmEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CustomSigningKeyAlgorithmEnum value,
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
        public const string Rs256 = "RS256";

        public const string Rs384 = "RS384";

        public const string Rs512 = "RS512";

        public const string Es256 = "ES256";

        public const string Es384 = "ES384";

        public const string Es512 = "ES512";

        public const string Ps256 = "PS256";

        public const string Ps384 = "PS384";

        public const string Ps512 = "PS512";
    }
}
