using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(ClientCredentialTypeEnum.ClientCredentialTypeEnumSerializer))]
[Serializable]
public readonly record struct ClientCredentialTypeEnum : IStringEnum
{
    public static readonly ClientCredentialTypeEnum PublicKey = new(Values.PublicKey);

    public static readonly ClientCredentialTypeEnum CertSubjectDn = new(Values.CertSubjectDn);

    public static readonly ClientCredentialTypeEnum X509Cert = new(Values.X509Cert);

    public ClientCredentialTypeEnum(string value)
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
    public static ClientCredentialTypeEnum FromCustom(string value)
    {
        return new ClientCredentialTypeEnum(value);
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

    public static bool operator ==(ClientCredentialTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ClientCredentialTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ClientCredentialTypeEnum value) => value.Value;

    public static explicit operator ClientCredentialTypeEnum(string value) => new(value);

    internal class ClientCredentialTypeEnumSerializer : JsonConverter<ClientCredentialTypeEnum>
    {
        public override ClientCredentialTypeEnum Read(
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
            return new ClientCredentialTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientCredentialTypeEnum value,
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
        public const string PublicKey = "public_key";

        public const string CertSubjectDn = "cert_subject_dn";

        public const string X509Cert = "x509_cert";
    }
}
