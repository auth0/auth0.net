using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(UserAttributeProfileUserIdOidcStrategyOverrideMapping.UserAttributeProfileUserIdOidcStrategyOverrideMappingSerializer)
)]
[Serializable]
public readonly record struct UserAttributeProfileUserIdOidcStrategyOverrideMapping : IStringEnum
{
    public static readonly UserAttributeProfileUserIdOidcStrategyOverrideMapping Sub = new(
        Values.Sub
    );

    public static readonly UserAttributeProfileUserIdOidcStrategyOverrideMapping Oid = new(
        Values.Oid
    );

    public static readonly UserAttributeProfileUserIdOidcStrategyOverrideMapping Email = new(
        Values.Email
    );

    public UserAttributeProfileUserIdOidcStrategyOverrideMapping(string value)
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
    public static UserAttributeProfileUserIdOidcStrategyOverrideMapping FromCustom(string value)
    {
        return new UserAttributeProfileUserIdOidcStrategyOverrideMapping(value);
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
        UserAttributeProfileUserIdOidcStrategyOverrideMapping value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        UserAttributeProfileUserIdOidcStrategyOverrideMapping value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        UserAttributeProfileUserIdOidcStrategyOverrideMapping value
    ) => value.Value;

    public static explicit operator UserAttributeProfileUserIdOidcStrategyOverrideMapping(
        string value
    ) => new(value);

    internal class UserAttributeProfileUserIdOidcStrategyOverrideMappingSerializer
        : JsonConverter<UserAttributeProfileUserIdOidcStrategyOverrideMapping>
    {
        public override UserAttributeProfileUserIdOidcStrategyOverrideMapping Read(
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
            return new UserAttributeProfileUserIdOidcStrategyOverrideMapping(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UserAttributeProfileUserIdOidcStrategyOverrideMapping value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UserAttributeProfileUserIdOidcStrategyOverrideMapping ReadAsPropertyName(
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
            return new UserAttributeProfileUserIdOidcStrategyOverrideMapping(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UserAttributeProfileUserIdOidcStrategyOverrideMapping value,
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
        public const string Sub = "sub";

        public const string Oid = "oid";

        public const string Email = "email";
    }
}
