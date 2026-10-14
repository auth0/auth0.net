using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(CimdExternalMetadataCreatedByEnum.CimdExternalMetadataCreatedByEnumSerializer)
)]
[Serializable]
public readonly record struct CimdExternalMetadataCreatedByEnum : IStringEnum
{
    public static readonly CimdExternalMetadataCreatedByEnum Admin = new(Values.Admin);

    public static readonly CimdExternalMetadataCreatedByEnum Client = new(Values.Client);

    public CimdExternalMetadataCreatedByEnum(string value)
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
    public static CimdExternalMetadataCreatedByEnum FromCustom(string value)
    {
        return new CimdExternalMetadataCreatedByEnum(value);
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

    public static bool operator ==(CimdExternalMetadataCreatedByEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CimdExternalMetadataCreatedByEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CimdExternalMetadataCreatedByEnum value) => value.Value;

    public static explicit operator CimdExternalMetadataCreatedByEnum(string value) => new(value);

    internal class CimdExternalMetadataCreatedByEnumSerializer
        : JsonConverter<CimdExternalMetadataCreatedByEnum>
    {
        public override CimdExternalMetadataCreatedByEnum Read(
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
            return new CimdExternalMetadataCreatedByEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CimdExternalMetadataCreatedByEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CimdExternalMetadataCreatedByEnum ReadAsPropertyName(
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
            return new CimdExternalMetadataCreatedByEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CimdExternalMetadataCreatedByEnum value,
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
        public const string Admin = "admin";

        public const string Client = "client";
    }
}
