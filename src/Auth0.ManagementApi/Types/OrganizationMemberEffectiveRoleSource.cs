using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(OrganizationMemberEffectiveRoleSource.OrganizationMemberEffectiveRoleSourceSerializer)
)]
[Serializable]
public readonly record struct OrganizationMemberEffectiveRoleSource : IStringEnum
{
    public static readonly OrganizationMemberEffectiveRoleSource Direct = new(Values.Direct);

    public static readonly OrganizationMemberEffectiveRoleSource Groups = new(Values.Groups);

    public OrganizationMemberEffectiveRoleSource(string value)
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
    public static OrganizationMemberEffectiveRoleSource FromCustom(string value)
    {
        return new OrganizationMemberEffectiveRoleSource(value);
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

    public static bool operator ==(OrganizationMemberEffectiveRoleSource value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OrganizationMemberEffectiveRoleSource value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OrganizationMemberEffectiveRoleSource value) =>
        value.Value;

    public static explicit operator OrganizationMemberEffectiveRoleSource(string value) =>
        new(value);

    internal class OrganizationMemberEffectiveRoleSourceSerializer
        : JsonConverter<OrganizationMemberEffectiveRoleSource>
    {
        public override OrganizationMemberEffectiveRoleSource Read(
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
            return new OrganizationMemberEffectiveRoleSource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OrganizationMemberEffectiveRoleSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override OrganizationMemberEffectiveRoleSource ReadAsPropertyName(
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
            return new OrganizationMemberEffectiveRoleSource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OrganizationMemberEffectiveRoleSource value,
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
        public const string Direct = "direct";

        public const string Groups = "groups";
    }
}
