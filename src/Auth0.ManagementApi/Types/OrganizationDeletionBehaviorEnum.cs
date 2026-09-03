using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(OrganizationDeletionBehaviorEnum.OrganizationDeletionBehaviorEnumSerializer))]
[Serializable]
public readonly record struct OrganizationDeletionBehaviorEnum : IStringEnum
{
    public static readonly OrganizationDeletionBehaviorEnum Allow = new(Values.Allow);

    public static readonly OrganizationDeletionBehaviorEnum AllowIfEmpty = new(Values.AllowIfEmpty);

    public OrganizationDeletionBehaviorEnum(string value)
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
    public static OrganizationDeletionBehaviorEnum FromCustom(string value)
    {
        return new OrganizationDeletionBehaviorEnum(value);
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

    public static bool operator ==(OrganizationDeletionBehaviorEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OrganizationDeletionBehaviorEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OrganizationDeletionBehaviorEnum value) => value.Value;

    public static explicit operator OrganizationDeletionBehaviorEnum(string value) => new(value);

    internal class OrganizationDeletionBehaviorEnumSerializer
        : JsonConverter<OrganizationDeletionBehaviorEnum>
    {
        public override OrganizationDeletionBehaviorEnum Read(
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
            return new OrganizationDeletionBehaviorEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OrganizationDeletionBehaviorEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override OrganizationDeletionBehaviorEnum ReadAsPropertyName(
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
            return new OrganizationDeletionBehaviorEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OrganizationDeletionBehaviorEnum value,
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
        public const string Allow = "allow";

        public const string AllowIfEmpty = "allow_if_empty";
    }
}
