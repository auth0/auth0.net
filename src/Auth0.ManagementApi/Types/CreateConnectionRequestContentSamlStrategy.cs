using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(CreateConnectionRequestContentSamlStrategy.CreateConnectionRequestContentSamlStrategySerializer)
)]
[Serializable]
public readonly record struct CreateConnectionRequestContentSamlStrategy : IStringEnum
{
    public static readonly CreateConnectionRequestContentSamlStrategy Samlp = new(Values.Samlp);

    public CreateConnectionRequestContentSamlStrategy(string value)
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
    public static CreateConnectionRequestContentSamlStrategy FromCustom(string value)
    {
        return new CreateConnectionRequestContentSamlStrategy(value);
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
        CreateConnectionRequestContentSamlStrategy value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateConnectionRequestContentSamlStrategy value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreateConnectionRequestContentSamlStrategy value) =>
        value.Value;

    public static explicit operator CreateConnectionRequestContentSamlStrategy(string value) =>
        new(value);

    internal class CreateConnectionRequestContentSamlStrategySerializer
        : JsonConverter<CreateConnectionRequestContentSamlStrategy>
    {
        public override CreateConnectionRequestContentSamlStrategy Read(
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
            return new CreateConnectionRequestContentSamlStrategy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateConnectionRequestContentSamlStrategy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateConnectionRequestContentSamlStrategy ReadAsPropertyName(
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
            return new CreateConnectionRequestContentSamlStrategy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateConnectionRequestContentSamlStrategy value,
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
        public const string Samlp = "samlp";
    }
}
