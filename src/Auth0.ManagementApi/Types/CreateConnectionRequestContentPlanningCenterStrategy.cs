using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(CreateConnectionRequestContentPlanningCenterStrategy.CreateConnectionRequestContentPlanningCenterStrategySerializer)
)]
[Serializable]
public readonly record struct CreateConnectionRequestContentPlanningCenterStrategy : IStringEnum
{
    public static readonly CreateConnectionRequestContentPlanningCenterStrategy Planningcenter =
        new(Values.Planningcenter);

    public CreateConnectionRequestContentPlanningCenterStrategy(string value)
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
    public static CreateConnectionRequestContentPlanningCenterStrategy FromCustom(string value)
    {
        return new CreateConnectionRequestContentPlanningCenterStrategy(value);
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
        CreateConnectionRequestContentPlanningCenterStrategy value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateConnectionRequestContentPlanningCenterStrategy value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateConnectionRequestContentPlanningCenterStrategy value
    ) => value.Value;

    public static explicit operator CreateConnectionRequestContentPlanningCenterStrategy(
        string value
    ) => new(value);

    internal class CreateConnectionRequestContentPlanningCenterStrategySerializer
        : JsonConverter<CreateConnectionRequestContentPlanningCenterStrategy>
    {
        public override CreateConnectionRequestContentPlanningCenterStrategy Read(
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
            return new CreateConnectionRequestContentPlanningCenterStrategy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateConnectionRequestContentPlanningCenterStrategy value,
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
        public const string Planningcenter = "planningcenter";
    }
}
