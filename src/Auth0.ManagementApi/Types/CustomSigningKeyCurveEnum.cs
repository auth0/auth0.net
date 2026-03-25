using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(CustomSigningKeyCurveEnum.CustomSigningKeyCurveEnumSerializer))]
[Serializable]
public readonly record struct CustomSigningKeyCurveEnum : IStringEnum
{
    public static readonly CustomSigningKeyCurveEnum P256 = new(Values.P256);

    public static readonly CustomSigningKeyCurveEnum P384 = new(Values.P384);

    public static readonly CustomSigningKeyCurveEnum P521 = new(Values.P521);

    public CustomSigningKeyCurveEnum(string value)
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
    public static CustomSigningKeyCurveEnum FromCustom(string value)
    {
        return new CustomSigningKeyCurveEnum(value);
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

    public static bool operator ==(CustomSigningKeyCurveEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CustomSigningKeyCurveEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CustomSigningKeyCurveEnum value) => value.Value;

    public static explicit operator CustomSigningKeyCurveEnum(string value) => new(value);

    internal class CustomSigningKeyCurveEnumSerializer : JsonConverter<CustomSigningKeyCurveEnum>
    {
        public override CustomSigningKeyCurveEnum Read(
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
            return new CustomSigningKeyCurveEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CustomSigningKeyCurveEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CustomSigningKeyCurveEnum ReadAsPropertyName(
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
            return new CustomSigningKeyCurveEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CustomSigningKeyCurveEnum value,
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
        public const string P256 = "P-256";

        public const string P384 = "P-384";

        public const string P521 = "P-521";
    }
}
