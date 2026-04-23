using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(ClientGrantDefaultForEnum.ClientGrantDefaultForEnumSerializer))]
[Serializable]
public readonly record struct ClientGrantDefaultForEnum : IStringEnum
{
    public static readonly ClientGrantDefaultForEnum ThirdPartyClients = new(
        Values.ThirdPartyClients
    );

    public ClientGrantDefaultForEnum(string value)
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
    public static ClientGrantDefaultForEnum FromCustom(string value)
    {
        return new ClientGrantDefaultForEnum(value);
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

    public static bool operator ==(ClientGrantDefaultForEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ClientGrantDefaultForEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ClientGrantDefaultForEnum value) => value.Value;

    public static explicit operator ClientGrantDefaultForEnum(string value) => new(value);

    internal class ClientGrantDefaultForEnumSerializer : JsonConverter<ClientGrantDefaultForEnum>
    {
        public override ClientGrantDefaultForEnum Read(
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
            return new ClientGrantDefaultForEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientGrantDefaultForEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ClientGrantDefaultForEnum ReadAsPropertyName(
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
            return new ClientGrantDefaultForEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ClientGrantDefaultForEnum value,
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
        public const string ThirdPartyClients = "third_party_clients";
    }
}
