using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ConnectionSetUserRootAttributesEnum.ConnectionSetUserRootAttributesEnumSerializer)
)]
[Serializable]
public readonly record struct ConnectionSetUserRootAttributesEnum : IStringEnum
{
    public static readonly ConnectionSetUserRootAttributesEnum OnEachLogin = new(
        Values.OnEachLogin
    );

    public static readonly ConnectionSetUserRootAttributesEnum OnFirstLogin = new(
        Values.OnFirstLogin
    );

    public static readonly ConnectionSetUserRootAttributesEnum NeverOnLogin = new(
        Values.NeverOnLogin
    );

    public ConnectionSetUserRootAttributesEnum(string value)
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
    public static ConnectionSetUserRootAttributesEnum FromCustom(string value)
    {
        return new ConnectionSetUserRootAttributesEnum(value);
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

    public static bool operator ==(ConnectionSetUserRootAttributesEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionSetUserRootAttributesEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionSetUserRootAttributesEnum value) =>
        value.Value;

    public static explicit operator ConnectionSetUserRootAttributesEnum(string value) => new(value);

    internal class ConnectionSetUserRootAttributesEnumSerializer
        : JsonConverter<ConnectionSetUserRootAttributesEnum>
    {
        public override ConnectionSetUserRootAttributesEnum Read(
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
            return new ConnectionSetUserRootAttributesEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionSetUserRootAttributesEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConnectionSetUserRootAttributesEnum ReadAsPropertyName(
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
            return new ConnectionSetUserRootAttributesEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConnectionSetUserRootAttributesEnum value,
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
        public const string OnEachLogin = "on_each_login";

        public const string OnFirstLogin = "on_first_login";

        public const string NeverOnLogin = "never_on_login";
    }
}
