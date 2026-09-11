using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(ResourceServerSortFieldEnum.ResourceServerSortFieldEnumSerializer))]
[Serializable]
public readonly record struct ResourceServerSortFieldEnum : IStringEnum
{
    public static readonly ResourceServerSortFieldEnum Identifier = new(Values.Identifier);

    public static readonly ResourceServerSortFieldEnum Name = new(Values.Name);

    public static readonly ResourceServerSortFieldEnum UpdatedAt = new(Values.UpdatedAt);

    public ResourceServerSortFieldEnum(string value)
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
    public static ResourceServerSortFieldEnum FromCustom(string value)
    {
        return new ResourceServerSortFieldEnum(value);
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

    public static bool operator ==(ResourceServerSortFieldEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ResourceServerSortFieldEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ResourceServerSortFieldEnum value) => value.Value;

    public static explicit operator ResourceServerSortFieldEnum(string value) => new(value);

    internal class ResourceServerSortFieldEnumSerializer
        : JsonConverter<ResourceServerSortFieldEnum>
    {
        public override ResourceServerSortFieldEnum Read(
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
            return new ResourceServerSortFieldEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ResourceServerSortFieldEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ResourceServerSortFieldEnum ReadAsPropertyName(
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
            return new ResourceServerSortFieldEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ResourceServerSortFieldEnum value,
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
        public const string Identifier = "identifier";

        public const string Name = "name";

        public const string UpdatedAt = "updated_at";
    }
}
