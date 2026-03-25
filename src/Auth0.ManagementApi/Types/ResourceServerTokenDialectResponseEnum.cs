using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ResourceServerTokenDialectResponseEnum.ResourceServerTokenDialectResponseEnumSerializer)
)]
[Serializable]
public readonly record struct ResourceServerTokenDialectResponseEnum : IStringEnum
{
    public static readonly ResourceServerTokenDialectResponseEnum AccessToken = new(
        Values.AccessToken
    );

    public static readonly ResourceServerTokenDialectResponseEnum AccessTokenAuthz = new(
        Values.AccessTokenAuthz
    );

    public static readonly ResourceServerTokenDialectResponseEnum Rfc9068Profile = new(
        Values.Rfc9068Profile
    );

    public static readonly ResourceServerTokenDialectResponseEnum Rfc9068ProfileAuthz = new(
        Values.Rfc9068ProfileAuthz
    );

    public ResourceServerTokenDialectResponseEnum(string value)
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
    public static ResourceServerTokenDialectResponseEnum FromCustom(string value)
    {
        return new ResourceServerTokenDialectResponseEnum(value);
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

    public static bool operator ==(ResourceServerTokenDialectResponseEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ResourceServerTokenDialectResponseEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ResourceServerTokenDialectResponseEnum value) =>
        value.Value;

    public static explicit operator ResourceServerTokenDialectResponseEnum(string value) =>
        new(value);

    internal class ResourceServerTokenDialectResponseEnumSerializer
        : JsonConverter<ResourceServerTokenDialectResponseEnum>
    {
        public override ResourceServerTokenDialectResponseEnum Read(
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
            return new ResourceServerTokenDialectResponseEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ResourceServerTokenDialectResponseEnum value,
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
