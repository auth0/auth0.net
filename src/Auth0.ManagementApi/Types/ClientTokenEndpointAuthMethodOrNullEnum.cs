using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ClientTokenEndpointAuthMethodOrNullEnum.ClientTokenEndpointAuthMethodOrNullEnumSerializer)
)]
[Serializable]
public readonly record struct ClientTokenEndpointAuthMethodOrNullEnum : IStringEnum
{
    public static readonly ClientTokenEndpointAuthMethodOrNullEnum None = new(Values.None);

    public static readonly ClientTokenEndpointAuthMethodOrNullEnum ClientSecretPost = new(
        Values.ClientSecretPost
    );

    public static readonly ClientTokenEndpointAuthMethodOrNullEnum ClientSecretBasic = new(
        Values.ClientSecretBasic
    );

    public ClientTokenEndpointAuthMethodOrNullEnum(string value)
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
    public static ClientTokenEndpointAuthMethodOrNullEnum FromCustom(string value)
    {
        return new ClientTokenEndpointAuthMethodOrNullEnum(value);
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

    public static bool operator ==(ClientTokenEndpointAuthMethodOrNullEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ClientTokenEndpointAuthMethodOrNullEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ClientTokenEndpointAuthMethodOrNullEnum value) =>
        value.Value;

    public static explicit operator ClientTokenEndpointAuthMethodOrNullEnum(string value) =>
        new(value);

    internal class ClientTokenEndpointAuthMethodOrNullEnumSerializer
        : JsonConverter<ClientTokenEndpointAuthMethodOrNullEnum>
    {
        public override ClientTokenEndpointAuthMethodOrNullEnum Read(
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
            return new ClientTokenEndpointAuthMethodOrNullEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientTokenEndpointAuthMethodOrNullEnum value,
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
