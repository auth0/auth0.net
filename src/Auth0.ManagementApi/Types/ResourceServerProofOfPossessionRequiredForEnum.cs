using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ResourceServerProofOfPossessionRequiredForEnum.ResourceServerProofOfPossessionRequiredForEnumSerializer)
)]
[Serializable]
public readonly record struct ResourceServerProofOfPossessionRequiredForEnum : IStringEnum
{
    public static readonly ResourceServerProofOfPossessionRequiredForEnum PublicClients = new(
        Values.PublicClients
    );

    public static readonly ResourceServerProofOfPossessionRequiredForEnum AllClients = new(
        Values.AllClients
    );

    public ResourceServerProofOfPossessionRequiredForEnum(string value)
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
    public static ResourceServerProofOfPossessionRequiredForEnum FromCustom(string value)
    {
        return new ResourceServerProofOfPossessionRequiredForEnum(value);
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
        ResourceServerProofOfPossessionRequiredForEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ResourceServerProofOfPossessionRequiredForEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ResourceServerProofOfPossessionRequiredForEnum value) =>
        value.Value;

    public static explicit operator ResourceServerProofOfPossessionRequiredForEnum(string value) =>
        new(value);

    internal class ResourceServerProofOfPossessionRequiredForEnumSerializer
        : JsonConverter<ResourceServerProofOfPossessionRequiredForEnum>
    {
        public override ResourceServerProofOfPossessionRequiredForEnum Read(
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
            return new ResourceServerProofOfPossessionRequiredForEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ResourceServerProofOfPossessionRequiredForEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ResourceServerProofOfPossessionRequiredForEnum ReadAsPropertyName(
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
            return new ResourceServerProofOfPossessionRequiredForEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ResourceServerProofOfPossessionRequiredForEnum value,
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
        public const string PublicClients = "public_clients";

        public const string AllClients = "all_clients";
    }
}
