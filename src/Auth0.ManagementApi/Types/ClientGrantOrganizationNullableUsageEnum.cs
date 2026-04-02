using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ClientGrantOrganizationNullableUsageEnum.ClientGrantOrganizationNullableUsageEnumSerializer)
)]
[Serializable]
public readonly record struct ClientGrantOrganizationNullableUsageEnum : IStringEnum
{
    public static readonly ClientGrantOrganizationNullableUsageEnum Deny = new(Values.Deny);

    public static readonly ClientGrantOrganizationNullableUsageEnum Allow = new(Values.Allow);

    public static readonly ClientGrantOrganizationNullableUsageEnum Require = new(Values.Require);

    public ClientGrantOrganizationNullableUsageEnum(string value)
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
    public static ClientGrantOrganizationNullableUsageEnum FromCustom(string value)
    {
        return new ClientGrantOrganizationNullableUsageEnum(value);
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
        ClientGrantOrganizationNullableUsageEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ClientGrantOrganizationNullableUsageEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ClientGrantOrganizationNullableUsageEnum value) =>
        value.Value;

    public static explicit operator ClientGrantOrganizationNullableUsageEnum(string value) =>
        new(value);

    internal class ClientGrantOrganizationNullableUsageEnumSerializer
        : JsonConverter<ClientGrantOrganizationNullableUsageEnum>
    {
        public override ClientGrantOrganizationNullableUsageEnum Read(
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
            return new ClientGrantOrganizationNullableUsageEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientGrantOrganizationNullableUsageEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ClientGrantOrganizationNullableUsageEnum ReadAsPropertyName(
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
            return new ClientGrantOrganizationNullableUsageEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ClientGrantOrganizationNullableUsageEnum value,
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
        public const string Deny = "deny";

        public const string Allow = "allow";

        public const string Require = "require";
    }
}
