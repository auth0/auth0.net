using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(UserEffectivePermissionRoleSourceEnum.UserEffectivePermissionRoleSourceEnumSerializer)
)]
[Serializable]
public readonly record struct UserEffectivePermissionRoleSourceEnum : IStringEnum
{
    public static readonly UserEffectivePermissionRoleSourceEnum Direct = new(Values.Direct);

    public static readonly UserEffectivePermissionRoleSourceEnum Groups = new(Values.Groups);

    public UserEffectivePermissionRoleSourceEnum(string value)
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
    public static UserEffectivePermissionRoleSourceEnum FromCustom(string value)
    {
        return new UserEffectivePermissionRoleSourceEnum(value);
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

    public static bool operator ==(UserEffectivePermissionRoleSourceEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UserEffectivePermissionRoleSourceEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UserEffectivePermissionRoleSourceEnum value) =>
        value.Value;

    public static explicit operator UserEffectivePermissionRoleSourceEnum(string value) =>
        new(value);

    internal class UserEffectivePermissionRoleSourceEnumSerializer
        : JsonConverter<UserEffectivePermissionRoleSourceEnum>
    {
        public override UserEffectivePermissionRoleSourceEnum Read(
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
            return new UserEffectivePermissionRoleSourceEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UserEffectivePermissionRoleSourceEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UserEffectivePermissionRoleSourceEnum ReadAsPropertyName(
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
            return new UserEffectivePermissionRoleSourceEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UserEffectivePermissionRoleSourceEnum value,
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
