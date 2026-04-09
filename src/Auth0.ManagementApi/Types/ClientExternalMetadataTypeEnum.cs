using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(ClientExternalMetadataTypeEnum.ClientExternalMetadataTypeEnumSerializer))]
[Serializable]
public readonly record struct ClientExternalMetadataTypeEnum : IStringEnum
{
    public static readonly ClientExternalMetadataTypeEnum Cimd = new(Values.Cimd);

    public ClientExternalMetadataTypeEnum(string value)
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
    public static ClientExternalMetadataTypeEnum FromCustom(string value)
    {
        return new ClientExternalMetadataTypeEnum(value);
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

    public static bool operator ==(ClientExternalMetadataTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ClientExternalMetadataTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ClientExternalMetadataTypeEnum value) => value.Value;

    public static explicit operator ClientExternalMetadataTypeEnum(string value) => new(value);

    internal class ClientExternalMetadataTypeEnumSerializer
        : JsonConverter<ClientExternalMetadataTypeEnum>
    {
        public override ClientExternalMetadataTypeEnum Read(
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
            return new ClientExternalMetadataTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientExternalMetadataTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ClientExternalMetadataTypeEnum ReadAsPropertyName(
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
            return new ClientExternalMetadataTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ClientExternalMetadataTypeEnum value,
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
        public const string Cimd = "cimd";
    }
}
