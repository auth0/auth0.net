using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(RoleTypeEnum.RoleTypeEnumSerializer))]
[Serializable]
public readonly record struct RoleTypeEnum : IStringEnum
{
    public static readonly RoleTypeEnum Tenant = new(Values.Tenant);

    public static readonly RoleTypeEnum Organization = new(Values.Organization);

    public RoleTypeEnum(string value)
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
    public static RoleTypeEnum FromCustom(string value)
    {
        return new RoleTypeEnum(value);
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

    public static bool operator ==(RoleTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(RoleTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(RoleTypeEnum value) => value.Value;

    public static explicit operator RoleTypeEnum(string value) => new(value);

    internal class RoleTypeEnumSerializer : JsonConverter<RoleTypeEnum>
    {
        public override RoleTypeEnum Read(
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
            return new RoleTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RoleTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RoleTypeEnum ReadAsPropertyName(
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
            return new RoleTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RoleTypeEnum value,
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
        public const string Tenant = "tenant";

        public const string Organization = "organization";
    }
}
