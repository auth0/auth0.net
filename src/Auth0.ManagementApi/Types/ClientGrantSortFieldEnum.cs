using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(ClientGrantSortFieldEnum.ClientGrantSortFieldEnumSerializer))]
[Serializable]
public readonly record struct ClientGrantSortFieldEnum : IStringEnum
{
    public static readonly ClientGrantSortFieldEnum Audience = new(Values.Audience);

    public static readonly ClientGrantSortFieldEnum UpdatedAt = new(Values.UpdatedAt);

    public ClientGrantSortFieldEnum(string value)
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
    public static ClientGrantSortFieldEnum FromCustom(string value)
    {
        return new ClientGrantSortFieldEnum(value);
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

    public static bool operator ==(ClientGrantSortFieldEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ClientGrantSortFieldEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ClientGrantSortFieldEnum value) => value.Value;

    public static explicit operator ClientGrantSortFieldEnum(string value) => new(value);

    internal class ClientGrantSortFieldEnumSerializer : JsonConverter<ClientGrantSortFieldEnum>
    {
        public override ClientGrantSortFieldEnum Read(
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
            return new ClientGrantSortFieldEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientGrantSortFieldEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ClientGrantSortFieldEnum ReadAsPropertyName(
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
            return new ClientGrantSortFieldEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ClientGrantSortFieldEnum value,
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
        public const string Audience = "audience";

        public const string UpdatedAt = "updated_at";
    }
}
