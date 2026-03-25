using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(ClientGrantSubjectTypeEnum.ClientGrantSubjectTypeEnumSerializer))]
[Serializable]
public readonly record struct ClientGrantSubjectTypeEnum : IStringEnum
{
    public static readonly ClientGrantSubjectTypeEnum Client = new(Values.Client);

    public static readonly ClientGrantSubjectTypeEnum User = new(Values.User);

    public ClientGrantSubjectTypeEnum(string value)
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
    public static ClientGrantSubjectTypeEnum FromCustom(string value)
    {
        return new ClientGrantSubjectTypeEnum(value);
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

    public static bool operator ==(ClientGrantSubjectTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ClientGrantSubjectTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ClientGrantSubjectTypeEnum value) => value.Value;

    public static explicit operator ClientGrantSubjectTypeEnum(string value) => new(value);

    internal class ClientGrantSubjectTypeEnumSerializer : JsonConverter<ClientGrantSubjectTypeEnum>
    {
        public override ClientGrantSubjectTypeEnum Read(
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
            return new ClientGrantSubjectTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientGrantSubjectTypeEnum value,
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
        public const string Client = "client";

        public const string User = "user";
    }
}
