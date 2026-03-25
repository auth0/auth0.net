using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ConnectionShouldTrustEmailVerifiedConnectionEnum.ConnectionShouldTrustEmailVerifiedConnectionEnumSerializer)
)]
[Serializable]
public readonly record struct ConnectionShouldTrustEmailVerifiedConnectionEnum : IStringEnum
{
    public static readonly ConnectionShouldTrustEmailVerifiedConnectionEnum NeverSetEmailsAsVerified =
        new(Values.NeverSetEmailsAsVerified);

    public static readonly ConnectionShouldTrustEmailVerifiedConnectionEnum AlwaysSetEmailsAsVerified =
        new(Values.AlwaysSetEmailsAsVerified);

    public ConnectionShouldTrustEmailVerifiedConnectionEnum(string value)
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
    public static ConnectionShouldTrustEmailVerifiedConnectionEnum FromCustom(string value)
    {
        return new ConnectionShouldTrustEmailVerifiedConnectionEnum(value);
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
        ConnectionShouldTrustEmailVerifiedConnectionEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ConnectionShouldTrustEmailVerifiedConnectionEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ConnectionShouldTrustEmailVerifiedConnectionEnum value
    ) => value.Value;

    public static explicit operator ConnectionShouldTrustEmailVerifiedConnectionEnum(
        string value
    ) => new(value);

    internal class ConnectionShouldTrustEmailVerifiedConnectionEnumSerializer
        : JsonConverter<ConnectionShouldTrustEmailVerifiedConnectionEnum>
    {
        public override ConnectionShouldTrustEmailVerifiedConnectionEnum Read(
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
            return new ConnectionShouldTrustEmailVerifiedConnectionEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionShouldTrustEmailVerifiedConnectionEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string NeverSetEmailsAsVerified = "never_set_emails_as_verified";

        public const string AlwaysSetEmailsAsVerified = "always_set_emails_as_verified";
    }
}
