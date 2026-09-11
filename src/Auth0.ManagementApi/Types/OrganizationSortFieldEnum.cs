using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(OrganizationSortFieldEnum.OrganizationSortFieldEnumSerializer))]
[Serializable]
public readonly record struct OrganizationSortFieldEnum : IStringEnum
{
    public static readonly OrganizationSortFieldEnum Name = new(Values.Name);

    public static readonly OrganizationSortFieldEnum DisplayName = new(Values.DisplayName);

    public static readonly OrganizationSortFieldEnum CreatedAt = new(Values.CreatedAt);

    public OrganizationSortFieldEnum(string value)
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
    public static OrganizationSortFieldEnum FromCustom(string value)
    {
        return new OrganizationSortFieldEnum(value);
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

    public static bool operator ==(OrganizationSortFieldEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OrganizationSortFieldEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OrganizationSortFieldEnum value) => value.Value;

    public static explicit operator OrganizationSortFieldEnum(string value) => new(value);

    internal class OrganizationSortFieldEnumSerializer : JsonConverter<OrganizationSortFieldEnum>
    {
        public override OrganizationSortFieldEnum Read(
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
            return new OrganizationSortFieldEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OrganizationSortFieldEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override OrganizationSortFieldEnum ReadAsPropertyName(
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
            return new OrganizationSortFieldEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OrganizationSortFieldEnum value,
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

        public const string DisplayName = "display_name";

        public const string CreatedAt = "created_at";
    }
}
