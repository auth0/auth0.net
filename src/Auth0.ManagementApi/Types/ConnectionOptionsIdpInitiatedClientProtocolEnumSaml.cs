using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ConnectionOptionsIdpInitiatedClientProtocolEnumSaml.ConnectionOptionsIdpInitiatedClientProtocolEnumSamlSerializer)
)]
[Serializable]
public readonly record struct ConnectionOptionsIdpInitiatedClientProtocolEnumSaml : IStringEnum
{
    public static readonly ConnectionOptionsIdpInitiatedClientProtocolEnumSaml Oidc = new(
        Values.Oidc
    );

    public static readonly ConnectionOptionsIdpInitiatedClientProtocolEnumSaml Samlp = new(
        Values.Samlp
    );

    public static readonly ConnectionOptionsIdpInitiatedClientProtocolEnumSaml Wsfed = new(
        Values.Wsfed
    );

    public ConnectionOptionsIdpInitiatedClientProtocolEnumSaml(string value)
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
    public static ConnectionOptionsIdpInitiatedClientProtocolEnumSaml FromCustom(string value)
    {
        return new ConnectionOptionsIdpInitiatedClientProtocolEnumSaml(value);
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
        ConnectionOptionsIdpInitiatedClientProtocolEnumSaml value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ConnectionOptionsIdpInitiatedClientProtocolEnumSaml value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ConnectionOptionsIdpInitiatedClientProtocolEnumSaml value
    ) => value.Value;

    public static explicit operator ConnectionOptionsIdpInitiatedClientProtocolEnumSaml(
        string value
    ) => new(value);

    internal class ConnectionOptionsIdpInitiatedClientProtocolEnumSamlSerializer
        : JsonConverter<ConnectionOptionsIdpInitiatedClientProtocolEnumSaml>
    {
        public override ConnectionOptionsIdpInitiatedClientProtocolEnumSaml Read(
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
            return new ConnectionOptionsIdpInitiatedClientProtocolEnumSaml(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionOptionsIdpInitiatedClientProtocolEnumSaml value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConnectionOptionsIdpInitiatedClientProtocolEnumSaml ReadAsPropertyName(
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
            return new ConnectionOptionsIdpInitiatedClientProtocolEnumSaml(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConnectionOptionsIdpInitiatedClientProtocolEnumSaml value,
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
        public const string Oidc = "oidc";

        public const string Samlp = "samlp";

        public const string Wsfed = "wsfed";
    }
}
