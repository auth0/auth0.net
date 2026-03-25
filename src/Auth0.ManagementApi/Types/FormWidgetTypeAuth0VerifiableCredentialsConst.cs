using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FormWidgetTypeAuth0VerifiableCredentialsConst.FormWidgetTypeAuth0VerifiableCredentialsConstSerializer)
)]
[Serializable]
public readonly record struct FormWidgetTypeAuth0VerifiableCredentialsConst : IStringEnum
{
    public static readonly FormWidgetTypeAuth0VerifiableCredentialsConst Auth0VerifiableCredentials =
        new(Values.Auth0VerifiableCredentials);

    public FormWidgetTypeAuth0VerifiableCredentialsConst(string value)
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
    public static FormWidgetTypeAuth0VerifiableCredentialsConst FromCustom(string value)
    {
        return new FormWidgetTypeAuth0VerifiableCredentialsConst(value);
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
        FormWidgetTypeAuth0VerifiableCredentialsConst value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        FormWidgetTypeAuth0VerifiableCredentialsConst value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(FormWidgetTypeAuth0VerifiableCredentialsConst value) =>
        value.Value;

    public static explicit operator FormWidgetTypeAuth0VerifiableCredentialsConst(string value) =>
        new(value);

    internal class FormWidgetTypeAuth0VerifiableCredentialsConstSerializer
        : JsonConverter<FormWidgetTypeAuth0VerifiableCredentialsConst>
    {
        public override FormWidgetTypeAuth0VerifiableCredentialsConst Read(
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
            return new FormWidgetTypeAuth0VerifiableCredentialsConst(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FormWidgetTypeAuth0VerifiableCredentialsConst value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FormWidgetTypeAuth0VerifiableCredentialsConst ReadAsPropertyName(
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
            return new FormWidgetTypeAuth0VerifiableCredentialsConst(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FormWidgetTypeAuth0VerifiableCredentialsConst value,
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
        public const string Auth0VerifiableCredentials = "AUTH0_VERIFIABLE_CREDENTIALS";
    }
}
