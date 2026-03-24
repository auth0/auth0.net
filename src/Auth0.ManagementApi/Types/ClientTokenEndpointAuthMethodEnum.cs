using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ClientTokenEndpointAuthMethodEnum.ClientTokenEndpointAuthMethodEnumSerializer)
)]
[Serializable]
public readonly record struct ClientTokenEndpointAuthMethodEnum : IStringEnum
{
    public static readonly ClientTokenEndpointAuthMethodEnum None = new(Values.None);

    public static readonly ClientTokenEndpointAuthMethodEnum ClientSecretPost = new(
        Values.ClientSecretPost
    );

    public static readonly ClientTokenEndpointAuthMethodEnum ClientSecretBasic = new(
        Values.ClientSecretBasic
    );

    public ClientTokenEndpointAuthMethodEnum(string value)
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
    public static ClientTokenEndpointAuthMethodEnum FromCustom(string value)
    {
        return new ClientTokenEndpointAuthMethodEnum(value);
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

    public static bool operator ==(ClientTokenEndpointAuthMethodEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ClientTokenEndpointAuthMethodEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ClientTokenEndpointAuthMethodEnum value) => value.Value;

    public static explicit operator ClientTokenEndpointAuthMethodEnum(string value) => new(value);

    internal class ClientTokenEndpointAuthMethodEnumSerializer
        : JsonConverter<ClientTokenEndpointAuthMethodEnum>
    {
        public override ClientTokenEndpointAuthMethodEnum Read(
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
            return new ClientTokenEndpointAuthMethodEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientTokenEndpointAuthMethodEnum value,
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
        public const string None = "none";

        public const string ClientSecretPost = "client_secret_post";

        public const string ClientSecretBasic = "client_secret_basic";
    }
}
