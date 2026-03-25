using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(CreateConnectionRequestContentDwollaStrategy.CreateConnectionRequestContentDwollaStrategySerializer)
)]
[Serializable]
public readonly record struct CreateConnectionRequestContentDwollaStrategy : IStringEnum
{
    public static readonly CreateConnectionRequestContentDwollaStrategy Dwolla = new(Values.Dwolla);

    public CreateConnectionRequestContentDwollaStrategy(string value)
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
    public static CreateConnectionRequestContentDwollaStrategy FromCustom(string value)
    {
        return new CreateConnectionRequestContentDwollaStrategy(value);
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
        CreateConnectionRequestContentDwollaStrategy value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateConnectionRequestContentDwollaStrategy value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreateConnectionRequestContentDwollaStrategy value) =>
        value.Value;

    public static explicit operator CreateConnectionRequestContentDwollaStrategy(string value) =>
        new(value);

    internal class CreateConnectionRequestContentDwollaStrategySerializer
        : JsonConverter<CreateConnectionRequestContentDwollaStrategy>
    {
        public override CreateConnectionRequestContentDwollaStrategy Read(
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
            return new CreateConnectionRequestContentDwollaStrategy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateConnectionRequestContentDwollaStrategy value,
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
        public const string Dwolla = "dwolla";
    }
}
