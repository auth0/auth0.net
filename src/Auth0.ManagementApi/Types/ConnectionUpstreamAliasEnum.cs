using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(ConnectionUpstreamAliasEnum.ConnectionUpstreamAliasEnumSerializer))]
[Serializable]
public readonly record struct ConnectionUpstreamAliasEnum : IStringEnum
{
    public static readonly ConnectionUpstreamAliasEnum AcrValues = new(Values.AcrValues);

    public static readonly ConnectionUpstreamAliasEnum Audience = new(Values.Audience);

    public static readonly ConnectionUpstreamAliasEnum ClientId = new(Values.ClientId);

    public static readonly ConnectionUpstreamAliasEnum Display = new(Values.Display);

    public static readonly ConnectionUpstreamAliasEnum IdTokenHint = new(Values.IdTokenHint);

    public static readonly ConnectionUpstreamAliasEnum LoginHint = new(Values.LoginHint);

    public static readonly ConnectionUpstreamAliasEnum MaxAge = new(Values.MaxAge);

    public static readonly ConnectionUpstreamAliasEnum Prompt = new(Values.Prompt);

    public static readonly ConnectionUpstreamAliasEnum Resource = new(Values.Resource);

    public static readonly ConnectionUpstreamAliasEnum ResponseMode = new(Values.ResponseMode);

    public static readonly ConnectionUpstreamAliasEnum ResponseType = new(Values.ResponseType);

    public static readonly ConnectionUpstreamAliasEnum UiLocales = new(Values.UiLocales);

    public ConnectionUpstreamAliasEnum(string value)
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
    public static ConnectionUpstreamAliasEnum FromCustom(string value)
    {
        return new ConnectionUpstreamAliasEnum(value);
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

    public static bool operator ==(ConnectionUpstreamAliasEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionUpstreamAliasEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionUpstreamAliasEnum value) => value.Value;

    public static explicit operator ConnectionUpstreamAliasEnum(string value) => new(value);

    internal class ConnectionUpstreamAliasEnumSerializer
        : JsonConverter<ConnectionUpstreamAliasEnum>
    {
        public override ConnectionUpstreamAliasEnum Read(
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
            return new ConnectionUpstreamAliasEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionUpstreamAliasEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConnectionUpstreamAliasEnum ReadAsPropertyName(
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
            return new ConnectionUpstreamAliasEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConnectionUpstreamAliasEnum value,
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
        public const string AcrValues = "acr_values";

        public const string Audience = "audience";

        public const string ClientId = "client_id";

        public const string Display = "display";

        public const string IdTokenHint = "id_token_hint";

        public const string LoginHint = "login_hint";

        public const string MaxAge = "max_age";

        public const string Prompt = "prompt";

        public const string Resource = "resource";

        public const string ResponseMode = "response_mode";

        public const string ResponseType = "response_type";

        public const string UiLocales = "ui_locales";
    }
}
