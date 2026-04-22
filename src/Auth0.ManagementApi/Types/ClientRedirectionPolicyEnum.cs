using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(ClientRedirectionPolicyEnum.ClientRedirectionPolicyEnumSerializer))]
[Serializable]
public readonly record struct ClientRedirectionPolicyEnum : IStringEnum
{
    public static readonly ClientRedirectionPolicyEnum AllowAlways = new(Values.AllowAlways);

    public static readonly ClientRedirectionPolicyEnum OpenRedirectProtection = new(
        Values.OpenRedirectProtection
    );

    public ClientRedirectionPolicyEnum(string value)
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
    public static ClientRedirectionPolicyEnum FromCustom(string value)
    {
        return new ClientRedirectionPolicyEnum(value);
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

    public static bool operator ==(ClientRedirectionPolicyEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ClientRedirectionPolicyEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ClientRedirectionPolicyEnum value) => value.Value;

    public static explicit operator ClientRedirectionPolicyEnum(string value) => new(value);

    internal class ClientRedirectionPolicyEnumSerializer
        : JsonConverter<ClientRedirectionPolicyEnum>
    {
        public override ClientRedirectionPolicyEnum Read(
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
            return new ClientRedirectionPolicyEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientRedirectionPolicyEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ClientRedirectionPolicyEnum ReadAsPropertyName(
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
            return new ClientRedirectionPolicyEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ClientRedirectionPolicyEnum value,
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
        public const string AllowAlways = "allow_always";

        public const string OpenRedirectProtection = "open_redirect_protection";
    }
}
