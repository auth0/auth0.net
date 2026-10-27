using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(ResourceServerTypeEnum.ResourceServerTypeEnumSerializer))]
[Serializable]
public readonly record struct ResourceServerTypeEnum : IStringEnum
{
    public static readonly ResourceServerTypeEnum UniversalCommerceProtocolServer = new(
        Values.UniversalCommerceProtocolServer
    );

    public ResourceServerTypeEnum(string value)
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
    public static ResourceServerTypeEnum FromCustom(string value)
    {
        return new ResourceServerTypeEnum(value);
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

    public static bool operator ==(ResourceServerTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ResourceServerTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ResourceServerTypeEnum value) => value.Value;

    public static explicit operator ResourceServerTypeEnum(string value) => new(value);

    internal class ResourceServerTypeEnumSerializer : JsonConverter<ResourceServerTypeEnum>
    {
        public override ResourceServerTypeEnum Read(
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
            return new ResourceServerTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ResourceServerTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ResourceServerTypeEnum ReadAsPropertyName(
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
            return new ResourceServerTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ResourceServerTypeEnum value,
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
        public const string UniversalCommerceProtocolServer = "universal_commerce_protocol_server";
    }
}
