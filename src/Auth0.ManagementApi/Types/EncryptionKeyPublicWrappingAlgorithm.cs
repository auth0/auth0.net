using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EncryptionKeyPublicWrappingAlgorithm.EncryptionKeyPublicWrappingAlgorithmSerializer)
)]
[Serializable]
public readonly record struct EncryptionKeyPublicWrappingAlgorithm : IStringEnum
{
    public static readonly EncryptionKeyPublicWrappingAlgorithm CkmRsaAesKeyWrap = new(
        Values.CkmRsaAesKeyWrap
    );

    public EncryptionKeyPublicWrappingAlgorithm(string value)
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
    public static EncryptionKeyPublicWrappingAlgorithm FromCustom(string value)
    {
        return new EncryptionKeyPublicWrappingAlgorithm(value);
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

    public static bool operator ==(EncryptionKeyPublicWrappingAlgorithm value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(EncryptionKeyPublicWrappingAlgorithm value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EncryptionKeyPublicWrappingAlgorithm value) =>
        value.Value;

    public static explicit operator EncryptionKeyPublicWrappingAlgorithm(string value) =>
        new(value);

    internal class EncryptionKeyPublicWrappingAlgorithmSerializer
        : JsonConverter<EncryptionKeyPublicWrappingAlgorithm>
    {
        public override EncryptionKeyPublicWrappingAlgorithm Read(
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
            return new EncryptionKeyPublicWrappingAlgorithm(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EncryptionKeyPublicWrappingAlgorithm value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EncryptionKeyPublicWrappingAlgorithm ReadAsPropertyName(
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
            return new EncryptionKeyPublicWrappingAlgorithm(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EncryptionKeyPublicWrappingAlgorithm value,
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
        public const string CkmRsaAesKeyWrap = "CKM_RSA_AES_KEY_WRAP";
    }
}
