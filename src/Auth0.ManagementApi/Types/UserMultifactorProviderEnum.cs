using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(UserMultifactorProviderEnum.UserMultifactorProviderEnumSerializer))]
[Serializable]
public readonly record struct UserMultifactorProviderEnum : IStringEnum
{
    public static readonly UserMultifactorProviderEnum Duo = new(Values.Duo);

    public static readonly UserMultifactorProviderEnum GoogleAuthenticator = new(
        Values.GoogleAuthenticator
    );

    public UserMultifactorProviderEnum(string value)
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
    public static UserMultifactorProviderEnum FromCustom(string value)
    {
        return new UserMultifactorProviderEnum(value);
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

    public static bool operator ==(UserMultifactorProviderEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UserMultifactorProviderEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UserMultifactorProviderEnum value) => value.Value;

    public static explicit operator UserMultifactorProviderEnum(string value) => new(value);

    internal class UserMultifactorProviderEnumSerializer
        : JsonConverter<UserMultifactorProviderEnum>
    {
        public override UserMultifactorProviderEnum Read(
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
            return new UserMultifactorProviderEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UserMultifactorProviderEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UserMultifactorProviderEnum ReadAsPropertyName(
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
            return new UserMultifactorProviderEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UserMultifactorProviderEnum value,
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
        public const string Duo = "duo";

        public const string GoogleAuthenticator = "google-authenticator";
    }
}
