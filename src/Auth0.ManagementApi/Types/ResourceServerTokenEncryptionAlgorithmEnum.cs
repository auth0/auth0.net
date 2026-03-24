using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ResourceServerTokenEncryptionAlgorithmEnum.ResourceServerTokenEncryptionAlgorithmEnumSerializer)
)]
[Serializable]
public readonly record struct ResourceServerTokenEncryptionAlgorithmEnum : IStringEnum
{
    public static readonly ResourceServerTokenEncryptionAlgorithmEnum RsaOaep256 = new(
        Values.RsaOaep256
    );

    public static readonly ResourceServerTokenEncryptionAlgorithmEnum RsaOaep384 = new(
        Values.RsaOaep384
    );

    public static readonly ResourceServerTokenEncryptionAlgorithmEnum RsaOaep512 = new(
        Values.RsaOaep512
    );

    public ResourceServerTokenEncryptionAlgorithmEnum(string value)
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
    public static ResourceServerTokenEncryptionAlgorithmEnum FromCustom(string value)
    {
        return new ResourceServerTokenEncryptionAlgorithmEnum(value);
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
        ResourceServerTokenEncryptionAlgorithmEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ResourceServerTokenEncryptionAlgorithmEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ResourceServerTokenEncryptionAlgorithmEnum value) =>
        value.Value;

    public static explicit operator ResourceServerTokenEncryptionAlgorithmEnum(string value) =>
        new(value);

    internal class ResourceServerTokenEncryptionAlgorithmEnumSerializer
        : JsonConverter<ResourceServerTokenEncryptionAlgorithmEnum>
    {
        public override ResourceServerTokenEncryptionAlgorithmEnum Read(
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
            return new ResourceServerTokenEncryptionAlgorithmEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ResourceServerTokenEncryptionAlgorithmEnum value,
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
        public const string RsaOaep256 = "RSA-OAEP-256";

        public const string RsaOaep384 = "RSA-OAEP-384";

        public const string RsaOaep512 = "RSA-OAEP-512";
    }
}
