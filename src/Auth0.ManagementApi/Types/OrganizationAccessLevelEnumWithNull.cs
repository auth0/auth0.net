using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(OrganizationAccessLevelEnumWithNull.OrganizationAccessLevelEnumWithNullSerializer)
)]
[Serializable]
public readonly record struct OrganizationAccessLevelEnumWithNull : IStringEnum
{
    public static readonly OrganizationAccessLevelEnumWithNull None = new(Values.None);

    public static readonly OrganizationAccessLevelEnumWithNull Readonly = new(Values.Readonly);

    public static readonly OrganizationAccessLevelEnumWithNull Limited = new(Values.Limited);

    public static readonly OrganizationAccessLevelEnumWithNull Full = new(Values.Full);

    public OrganizationAccessLevelEnumWithNull(string value)
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
    public static OrganizationAccessLevelEnumWithNull FromCustom(string value)
    {
        return new OrganizationAccessLevelEnumWithNull(value);
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

    public static bool operator ==(OrganizationAccessLevelEnumWithNull value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OrganizationAccessLevelEnumWithNull value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OrganizationAccessLevelEnumWithNull value) =>
        value.Value;

    public static explicit operator OrganizationAccessLevelEnumWithNull(string value) => new(value);

    internal class OrganizationAccessLevelEnumWithNullSerializer
        : JsonConverter<OrganizationAccessLevelEnumWithNull>
    {
        public override OrganizationAccessLevelEnumWithNull Read(
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
            return new OrganizationAccessLevelEnumWithNull(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OrganizationAccessLevelEnumWithNull value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override OrganizationAccessLevelEnumWithNull ReadAsPropertyName(
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
            return new OrganizationAccessLevelEnumWithNull(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OrganizationAccessLevelEnumWithNull value,
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
        public const string None = "none";

        public const string Readonly = "readonly";

        public const string Limited = "limited";

        public const string Full = "full";
    }
}
