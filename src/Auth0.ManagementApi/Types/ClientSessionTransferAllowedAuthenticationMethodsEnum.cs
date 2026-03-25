using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ClientSessionTransferAllowedAuthenticationMethodsEnum.ClientSessionTransferAllowedAuthenticationMethodsEnumSerializer)
)]
[Serializable]
public readonly record struct ClientSessionTransferAllowedAuthenticationMethodsEnum : IStringEnum
{
    public static readonly ClientSessionTransferAllowedAuthenticationMethodsEnum Cookie = new(
        Values.Cookie
    );

    public static readonly ClientSessionTransferAllowedAuthenticationMethodsEnum Query = new(
        Values.Query
    );

    public ClientSessionTransferAllowedAuthenticationMethodsEnum(string value)
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
    public static ClientSessionTransferAllowedAuthenticationMethodsEnum FromCustom(string value)
    {
        return new ClientSessionTransferAllowedAuthenticationMethodsEnum(value);
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
        ClientSessionTransferAllowedAuthenticationMethodsEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ClientSessionTransferAllowedAuthenticationMethodsEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ClientSessionTransferAllowedAuthenticationMethodsEnum value
    ) => value.Value;

    public static explicit operator ClientSessionTransferAllowedAuthenticationMethodsEnum(
        string value
    ) => new(value);

    internal class ClientSessionTransferAllowedAuthenticationMethodsEnumSerializer
        : JsonConverter<ClientSessionTransferAllowedAuthenticationMethodsEnum>
    {
        public override ClientSessionTransferAllowedAuthenticationMethodsEnum Read(
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
            return new ClientSessionTransferAllowedAuthenticationMethodsEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientSessionTransferAllowedAuthenticationMethodsEnum value,
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
        public const string Cookie = "cookie";

        public const string Query = "query";
    }
}
