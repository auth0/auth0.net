using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(CreateConnectionRequestContentAuth0OidcStrategy.CreateConnectionRequestContentAuth0OidcStrategySerializer)
)]
[Serializable]
public readonly record struct CreateConnectionRequestContentAuth0OidcStrategy : IStringEnum
{
    public static readonly CreateConnectionRequestContentAuth0OidcStrategy Auth0Oidc = new(
        Values.Auth0Oidc
    );

    public CreateConnectionRequestContentAuth0OidcStrategy(string value)
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
    public static CreateConnectionRequestContentAuth0OidcStrategy FromCustom(string value)
    {
        return new CreateConnectionRequestContentAuth0OidcStrategy(value);
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
        CreateConnectionRequestContentAuth0OidcStrategy value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateConnectionRequestContentAuth0OidcStrategy value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreateConnectionRequestContentAuth0OidcStrategy value) =>
        value.Value;

    public static explicit operator CreateConnectionRequestContentAuth0OidcStrategy(string value) =>
        new(value);

    internal class CreateConnectionRequestContentAuth0OidcStrategySerializer
        : JsonConverter<CreateConnectionRequestContentAuth0OidcStrategy>
    {
        public override CreateConnectionRequestContentAuth0OidcStrategy Read(
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
            return new CreateConnectionRequestContentAuth0OidcStrategy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateConnectionRequestContentAuth0OidcStrategy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateConnectionRequestContentAuth0OidcStrategy ReadAsPropertyName(
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
            return new CreateConnectionRequestContentAuth0OidcStrategy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateConnectionRequestContentAuth0OidcStrategy value,
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
        public const string Auth0Oidc = "auth0-oidc";
    }
}
