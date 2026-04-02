using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(ClientCredentialAlgorithmEnum.ClientCredentialAlgorithmEnumSerializer))]
[Serializable]
public readonly record struct ClientCredentialAlgorithmEnum : IStringEnum
{
    public static readonly ClientCredentialAlgorithmEnum Rs256 = new(Values.Rs256);

    public static readonly ClientCredentialAlgorithmEnum Rs384 = new(Values.Rs384);

    public static readonly ClientCredentialAlgorithmEnum Ps256 = new(Values.Ps256);

    public ClientCredentialAlgorithmEnum(string value)
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
    public static ClientCredentialAlgorithmEnum FromCustom(string value)
    {
        return new ClientCredentialAlgorithmEnum(value);
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

    public static bool operator ==(ClientCredentialAlgorithmEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ClientCredentialAlgorithmEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ClientCredentialAlgorithmEnum value) => value.Value;

    public static explicit operator ClientCredentialAlgorithmEnum(string value) => new(value);

    internal class ClientCredentialAlgorithmEnumSerializer
        : JsonConverter<ClientCredentialAlgorithmEnum>
    {
        public override ClientCredentialAlgorithmEnum Read(
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
            return new ClientCredentialAlgorithmEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientCredentialAlgorithmEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ClientCredentialAlgorithmEnum ReadAsPropertyName(
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
            return new ClientCredentialAlgorithmEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ClientCredentialAlgorithmEnum value,
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
        public const string Rs256 = "RS256";

        public const string Rs384 = "RS384";

        public const string Ps256 = "PS256";
    }
}
