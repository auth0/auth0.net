using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ResourceServerTokenDialectSchemaEnum.ResourceServerTokenDialectSchemaEnumSerializer)
)]
[Serializable]
public readonly record struct ResourceServerTokenDialectSchemaEnum : IStringEnum
{
    public static readonly ResourceServerTokenDialectSchemaEnum AccessToken = new(
        Values.AccessToken
    );

    public static readonly ResourceServerTokenDialectSchemaEnum AccessTokenAuthz = new(
        Values.AccessTokenAuthz
    );

    public static readonly ResourceServerTokenDialectSchemaEnum Rfc9068Profile = new(
        Values.Rfc9068Profile
    );

    public static readonly ResourceServerTokenDialectSchemaEnum Rfc9068ProfileAuthz = new(
        Values.Rfc9068ProfileAuthz
    );

    public ResourceServerTokenDialectSchemaEnum(string value)
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
    public static ResourceServerTokenDialectSchemaEnum FromCustom(string value)
    {
        return new ResourceServerTokenDialectSchemaEnum(value);
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

    public static bool operator ==(ResourceServerTokenDialectSchemaEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ResourceServerTokenDialectSchemaEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ResourceServerTokenDialectSchemaEnum value) =>
        value.Value;

    public static explicit operator ResourceServerTokenDialectSchemaEnum(string value) =>
        new(value);

    internal class ResourceServerTokenDialectSchemaEnumSerializer
        : JsonConverter<ResourceServerTokenDialectSchemaEnum>
    {
        public override ResourceServerTokenDialectSchemaEnum Read(
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
            return new ResourceServerTokenDialectSchemaEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ResourceServerTokenDialectSchemaEnum value,
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
        public const string AccessToken = "access_token";

        public const string AccessTokenAuthz = "access_token_authz";

        public const string Rfc9068Profile = "rfc9068_profile";

        public const string Rfc9068ProfileAuthz = "rfc9068_profile_authz";
    }
}
