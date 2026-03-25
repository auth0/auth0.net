using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(CreateConnectionRequestContentYandexStrategy.CreateConnectionRequestContentYandexStrategySerializer)
)]
[Serializable]
public readonly record struct CreateConnectionRequestContentYandexStrategy : IStringEnum
{
    public static readonly CreateConnectionRequestContentYandexStrategy Yandex = new(Values.Yandex);

    public CreateConnectionRequestContentYandexStrategy(string value)
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
    public static CreateConnectionRequestContentYandexStrategy FromCustom(string value)
    {
        return new CreateConnectionRequestContentYandexStrategy(value);
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
        CreateConnectionRequestContentYandexStrategy value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateConnectionRequestContentYandexStrategy value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreateConnectionRequestContentYandexStrategy value) =>
        value.Value;

    public static explicit operator CreateConnectionRequestContentYandexStrategy(string value) =>
        new(value);

    internal class CreateConnectionRequestContentYandexStrategySerializer
        : JsonConverter<CreateConnectionRequestContentYandexStrategy>
    {
        public override CreateConnectionRequestContentYandexStrategy Read(
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
            return new CreateConnectionRequestContentYandexStrategy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateConnectionRequestContentYandexStrategy value,
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
        public const string Yandex = "yandex";
    }
}
