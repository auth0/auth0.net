using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(ClientOrganizationUsageEnum.ClientOrganizationUsageEnumSerializer))]
[Serializable]
public readonly record struct ClientOrganizationUsageEnum : IStringEnum
{
    public static readonly ClientOrganizationUsageEnum Deny = new(Values.Deny);

    public static readonly ClientOrganizationUsageEnum Allow = new(Values.Allow);

    public static readonly ClientOrganizationUsageEnum Require = new(Values.Require);

    public ClientOrganizationUsageEnum(string value)
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
    public static ClientOrganizationUsageEnum FromCustom(string value)
    {
        return new ClientOrganizationUsageEnum(value);
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

    public static bool operator ==(ClientOrganizationUsageEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ClientOrganizationUsageEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ClientOrganizationUsageEnum value) => value.Value;

    public static explicit operator ClientOrganizationUsageEnum(string value) => new(value);

    internal class ClientOrganizationUsageEnumSerializer
        : JsonConverter<ClientOrganizationUsageEnum>
    {
        public override ClientOrganizationUsageEnum Read(
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
            return new ClientOrganizationUsageEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientOrganizationUsageEnum value,
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
        public const string Deny = "deny";

        public const string Allow = "allow";

        public const string Require = "require";
    }
}
