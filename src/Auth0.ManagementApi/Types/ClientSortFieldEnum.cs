using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(ClientSortFieldEnum.ClientSortFieldEnumSerializer))]
[Serializable]
public readonly record struct ClientSortFieldEnum : IStringEnum
{
    public static readonly ClientSortFieldEnum Name = new(Values.Name);

    public static readonly ClientSortFieldEnum UpdatedAt = new(Values.UpdatedAt);

    public ClientSortFieldEnum(string value)
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
    public static ClientSortFieldEnum FromCustom(string value)
    {
        return new ClientSortFieldEnum(value);
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

    public static bool operator ==(ClientSortFieldEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ClientSortFieldEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ClientSortFieldEnum value) => value.Value;

    public static explicit operator ClientSortFieldEnum(string value) => new(value);

    internal class ClientSortFieldEnumSerializer : JsonConverter<ClientSortFieldEnum>
    {
        public override ClientSortFieldEnum Read(
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
            return new ClientSortFieldEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientSortFieldEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ClientSortFieldEnum ReadAsPropertyName(
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
            return new ClientSortFieldEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ClientSortFieldEnum value,
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
        public const string Name = "name";

        public const string UpdatedAt = "updated_at";
    }
}
