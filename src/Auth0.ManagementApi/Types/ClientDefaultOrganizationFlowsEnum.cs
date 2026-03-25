using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ClientDefaultOrganizationFlowsEnum.ClientDefaultOrganizationFlowsEnumSerializer)
)]
[Serializable]
public readonly record struct ClientDefaultOrganizationFlowsEnum : IStringEnum
{
    public static readonly ClientDefaultOrganizationFlowsEnum ClientCredentials = new(
        Values.ClientCredentials
    );

    public ClientDefaultOrganizationFlowsEnum(string value)
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
    public static ClientDefaultOrganizationFlowsEnum FromCustom(string value)
    {
        return new ClientDefaultOrganizationFlowsEnum(value);
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

    public static bool operator ==(ClientDefaultOrganizationFlowsEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ClientDefaultOrganizationFlowsEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ClientDefaultOrganizationFlowsEnum value) => value.Value;

    public static explicit operator ClientDefaultOrganizationFlowsEnum(string value) => new(value);

    internal class ClientDefaultOrganizationFlowsEnumSerializer
        : JsonConverter<ClientDefaultOrganizationFlowsEnum>
    {
        public override ClientDefaultOrganizationFlowsEnum Read(
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
            return new ClientDefaultOrganizationFlowsEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientDefaultOrganizationFlowsEnum value,
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
        public const string ClientCredentials = "client_credentials";
    }
}
