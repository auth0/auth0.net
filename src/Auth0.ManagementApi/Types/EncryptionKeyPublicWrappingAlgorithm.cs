using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<EncryptionKeyPublicWrappingAlgorithm>))]
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

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string CkmRsaAesKeyWrap = "CKM_RSA_AES_KEY_WRAP";
    }
}
