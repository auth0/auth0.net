using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ConnectionTokenEndpointJwtcaAudFormatEnumOidc.ConnectionTokenEndpointJwtcaAudFormatEnumOidcSerializer)
)]
[Serializable]
public readonly record struct ConnectionTokenEndpointJwtcaAudFormatEnumOidc : IStringEnum
{
    public static readonly ConnectionTokenEndpointJwtcaAudFormatEnumOidc Issuer = new(
        Values.Issuer
    );

    public static readonly ConnectionTokenEndpointJwtcaAudFormatEnumOidc TokenEndpoint = new(
        Values.TokenEndpoint
    );

    public ConnectionTokenEndpointJwtcaAudFormatEnumOidc(string value)
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
    public static ConnectionTokenEndpointJwtcaAudFormatEnumOidc FromCustom(string value)
    {
        return new ConnectionTokenEndpointJwtcaAudFormatEnumOidc(value);
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
        ConnectionTokenEndpointJwtcaAudFormatEnumOidc value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ConnectionTokenEndpointJwtcaAudFormatEnumOidc value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionTokenEndpointJwtcaAudFormatEnumOidc value) =>
        value.Value;

    public static explicit operator ConnectionTokenEndpointJwtcaAudFormatEnumOidc(string value) =>
        new(value);

    internal class ConnectionTokenEndpointJwtcaAudFormatEnumOidcSerializer
        : JsonConverter<ConnectionTokenEndpointJwtcaAudFormatEnumOidc>
    {
        public override ConnectionTokenEndpointJwtcaAudFormatEnumOidc Read(
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
            return new ConnectionTokenEndpointJwtcaAudFormatEnumOidc(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionTokenEndpointJwtcaAudFormatEnumOidc value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConnectionTokenEndpointJwtcaAudFormatEnumOidc ReadAsPropertyName(
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
            return new ConnectionTokenEndpointJwtcaAudFormatEnumOidc(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConnectionTokenEndpointJwtcaAudFormatEnumOidc value,
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
        public const string Issuer = "issuer";

        public const string TokenEndpoint = "token_endpoint";
    }
}
