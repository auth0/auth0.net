using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(EncryptionKeyType.EncryptionKeyTypeSerializer))]
[Serializable]
public readonly record struct EncryptionKeyType : IStringEnum
{
    public static readonly EncryptionKeyType CustomerProvidedRootKey = new(
        Values.CustomerProvidedRootKey
    );

    public static readonly EncryptionKeyType EnvironmentRootKey = new(Values.EnvironmentRootKey);

    public static readonly EncryptionKeyType TenantMasterKey = new(Values.TenantMasterKey);

    public static readonly EncryptionKeyType TenantEncryptionKey = new(Values.TenantEncryptionKey);

    public EncryptionKeyType(string value)
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
    public static EncryptionKeyType FromCustom(string value)
    {
        return new EncryptionKeyType(value);
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

    public static bool operator ==(EncryptionKeyType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(EncryptionKeyType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EncryptionKeyType value) => value.Value;

    public static explicit operator EncryptionKeyType(string value) => new(value);

    internal class EncryptionKeyTypeSerializer : JsonConverter<EncryptionKeyType>
    {
        public override EncryptionKeyType Read(
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
            return new EncryptionKeyType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EncryptionKeyType value,
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

        public const string EnvironmentRootKey = "environment-root-key";

        public const string TenantMasterKey = "tenant-master-key";

        public const string TenantEncryptionKey = "tenant-encryption-key";
    }
}
