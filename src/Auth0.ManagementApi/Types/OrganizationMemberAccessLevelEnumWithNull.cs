using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(OrganizationMemberAccessLevelEnumWithNull.OrganizationMemberAccessLevelEnumWithNullSerializer)
)]
[Serializable]
public readonly record struct OrganizationMemberAccessLevelEnumWithNull : IStringEnum
{
    public static readonly OrganizationMemberAccessLevelEnumWithNull None = new(Values.None);

    public static readonly OrganizationMemberAccessLevelEnumWithNull Readonly = new(
        Values.Readonly
    );

    public static readonly OrganizationMemberAccessLevelEnumWithNull Limited = new(Values.Limited);

    public static readonly OrganizationMemberAccessLevelEnumWithNull Full = new(Values.Full);

    public OrganizationMemberAccessLevelEnumWithNull(string value)
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
    public static OrganizationMemberAccessLevelEnumWithNull FromCustom(string value)
    {
        return new OrganizationMemberAccessLevelEnumWithNull(value);
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
        OrganizationMemberAccessLevelEnumWithNull value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        OrganizationMemberAccessLevelEnumWithNull value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(OrganizationMemberAccessLevelEnumWithNull value) =>
        value.Value;

    public static explicit operator OrganizationMemberAccessLevelEnumWithNull(string value) =>
        new(value);

    internal class OrganizationMemberAccessLevelEnumWithNullSerializer
        : JsonConverter<OrganizationMemberAccessLevelEnumWithNull>
    {
        public override OrganizationMemberAccessLevelEnumWithNull Read(
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
            return new OrganizationMemberAccessLevelEnumWithNull(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OrganizationMemberAccessLevelEnumWithNull value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override OrganizationMemberAccessLevelEnumWithNull ReadAsPropertyName(
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
            return new OrganizationMemberAccessLevelEnumWithNull(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OrganizationMemberAccessLevelEnumWithNull value,
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
