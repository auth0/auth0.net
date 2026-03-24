using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(CreateEncryptionKeyType.CreateEncryptionKeyTypeSerializer))]
[Serializable]
public readonly record struct CreateEncryptionKeyType : IStringEnum
{
    public static readonly CreateEncryptionKeyType CustomerProvidedRootKey = new(
        Values.CustomerProvidedRootKey
    );

    public static readonly CreateEncryptionKeyType TenantEncryptionKey = new(
        Values.TenantEncryptionKey
    );

    public CreateEncryptionKeyType(string value)
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
    public static CreateEncryptionKeyType FromCustom(string value)
    {
        return new CreateEncryptionKeyType(value);
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

    public static bool operator ==(CreateEncryptionKeyType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateEncryptionKeyType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateEncryptionKeyType value) => value.Value;

    public static explicit operator CreateEncryptionKeyType(string value) => new(value);

    internal class CreateEncryptionKeyTypeSerializer : JsonConverter<CreateEncryptionKeyType>
    {
        public override CreateEncryptionKeyType Read(
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
            return new CreateEncryptionKeyType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateEncryptionKeyType value,
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
        public const string CustomerProvidedRootKey = "customer-provided-root-key";

        public const string TenantEncryptionKey = "tenant-encryption-key";
    }
}
