using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(CertificateSubjectDnCredentialTypeEnum.CertificateSubjectDnCredentialTypeEnumSerializer)
)]
[Serializable]
public readonly record struct CertificateSubjectDnCredentialTypeEnum : IStringEnum
{
    public static readonly CertificateSubjectDnCredentialTypeEnum CertSubjectDn = new(
        Values.CertSubjectDn
    );

    public CertificateSubjectDnCredentialTypeEnum(string value)
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
    public static CertificateSubjectDnCredentialTypeEnum FromCustom(string value)
    {
        return new CertificateSubjectDnCredentialTypeEnum(value);
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

    public static bool operator ==(CertificateSubjectDnCredentialTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CertificateSubjectDnCredentialTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CertificateSubjectDnCredentialTypeEnum value) =>
        value.Value;

    public static explicit operator CertificateSubjectDnCredentialTypeEnum(string value) =>
        new(value);

    internal class CertificateSubjectDnCredentialTypeEnumSerializer
        : JsonConverter<CertificateSubjectDnCredentialTypeEnum>
    {
        public override CertificateSubjectDnCredentialTypeEnum Read(
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
            return new CertificateSubjectDnCredentialTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CertificateSubjectDnCredentialTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CertificateSubjectDnCredentialTypeEnum ReadAsPropertyName(
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
            return new CertificateSubjectDnCredentialTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CertificateSubjectDnCredentialTypeEnum value,
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
        public const string CertSubjectDn = "cert_subject_dn";
    }
}
