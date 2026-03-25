using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(PublicKeyCredentialAlgorithmEnum.PublicKeyCredentialAlgorithmEnumSerializer))]
[Serializable]
public readonly record struct PublicKeyCredentialAlgorithmEnum : IStringEnum
{
    public static readonly PublicKeyCredentialAlgorithmEnum Rs256 = new(Values.Rs256);

    public static readonly PublicKeyCredentialAlgorithmEnum Rs384 = new(Values.Rs384);

    public static readonly PublicKeyCredentialAlgorithmEnum Ps256 = new(Values.Ps256);

    public PublicKeyCredentialAlgorithmEnum(string value)
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
    public static PublicKeyCredentialAlgorithmEnum FromCustom(string value)
    {
        return new PublicKeyCredentialAlgorithmEnum(value);
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

    public static bool operator ==(PublicKeyCredentialAlgorithmEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PublicKeyCredentialAlgorithmEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PublicKeyCredentialAlgorithmEnum value) => value.Value;

    public static explicit operator PublicKeyCredentialAlgorithmEnum(string value) => new(value);

    internal class PublicKeyCredentialAlgorithmEnumSerializer
        : JsonConverter<PublicKeyCredentialAlgorithmEnum>
    {
        public override PublicKeyCredentialAlgorithmEnum Read(
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
            return new PublicKeyCredentialAlgorithmEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PublicKeyCredentialAlgorithmEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PublicKeyCredentialAlgorithmEnum ReadAsPropertyName(
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
            return new PublicKeyCredentialAlgorithmEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PublicKeyCredentialAlgorithmEnum value,
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

        public const string Ps256 = "PS256";
    }
}
