using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(CreateConnectionRequestContentDropboxStrategy.CreateConnectionRequestContentDropboxStrategySerializer)
)]
[Serializable]
public readonly record struct CreateConnectionRequestContentDropboxStrategy : IStringEnum
{
    public static readonly CreateConnectionRequestContentDropboxStrategy Dropbox = new(
        Values.Dropbox
    );

    public CreateConnectionRequestContentDropboxStrategy(string value)
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
    public static CreateConnectionRequestContentDropboxStrategy FromCustom(string value)
    {
        return new CreateConnectionRequestContentDropboxStrategy(value);
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
        CreateConnectionRequestContentDropboxStrategy value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateConnectionRequestContentDropboxStrategy value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreateConnectionRequestContentDropboxStrategy value) =>
        value.Value;

    public static explicit operator CreateConnectionRequestContentDropboxStrategy(string value) =>
        new(value);

    internal class CreateConnectionRequestContentDropboxStrategySerializer
        : JsonConverter<CreateConnectionRequestContentDropboxStrategy>
    {
        public override CreateConnectionRequestContentDropboxStrategy Read(
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
            return new CreateConnectionRequestContentDropboxStrategy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateConnectionRequestContentDropboxStrategy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateConnectionRequestContentDropboxStrategy ReadAsPropertyName(
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
            return new CreateConnectionRequestContentDropboxStrategy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateConnectionRequestContentDropboxStrategy value,
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
        public const string Dropbox = "dropbox";
    }
}
