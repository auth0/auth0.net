using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(ExperimentTransitionStatusEnum.ExperimentTransitionStatusEnumSerializer))]
[Serializable]
public readonly record struct ExperimentTransitionStatusEnum : IStringEnum
{
    public static readonly ExperimentTransitionStatusEnum Active = new(Values.Active);

    public static readonly ExperimentTransitionStatusEnum Paused = new(Values.Paused);

    public static readonly ExperimentTransitionStatusEnum Completed = new(Values.Completed);

    public static readonly ExperimentTransitionStatusEnum Archived = new(Values.Archived);

    public ExperimentTransitionStatusEnum(string value)
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
    public static ExperimentTransitionStatusEnum FromCustom(string value)
    {
        return new ExperimentTransitionStatusEnum(value);
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

    public static bool operator ==(ExperimentTransitionStatusEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ExperimentTransitionStatusEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ExperimentTransitionStatusEnum value) => value.Value;

    public static explicit operator ExperimentTransitionStatusEnum(string value) => new(value);

    internal class ExperimentTransitionStatusEnumSerializer
        : JsonConverter<ExperimentTransitionStatusEnum>
    {
        public override ExperimentTransitionStatusEnum Read(
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
            return new ExperimentTransitionStatusEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ExperimentTransitionStatusEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ExperimentTransitionStatusEnum ReadAsPropertyName(
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
            return new ExperimentTransitionStatusEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ExperimentTransitionStatusEnum value,
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
        public const string Active = "active";

        public const string Paused = "paused";

        public const string Completed = "completed";

        public const string Archived = "archived";
    }
}
