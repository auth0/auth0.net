using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(ActionBindingTypeEnum.ActionBindingTypeEnumSerializer))]
[Serializable]
public readonly record struct ActionBindingTypeEnum : IStringEnum
{
    public static readonly ActionBindingTypeEnum TriggerBound = new(Values.TriggerBound);

    public static readonly ActionBindingTypeEnum EntityBound = new(Values.EntityBound);

    public ActionBindingTypeEnum(string value)
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
    public static ActionBindingTypeEnum FromCustom(string value)
    {
        return new ActionBindingTypeEnum(value);
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

    public static bool operator ==(ActionBindingTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ActionBindingTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ActionBindingTypeEnum value) => value.Value;

    public static explicit operator ActionBindingTypeEnum(string value) => new(value);

    internal class ActionBindingTypeEnumSerializer : JsonConverter<ActionBindingTypeEnum>
    {
        public override ActionBindingTypeEnum Read(
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
            return new ActionBindingTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ActionBindingTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ActionBindingTypeEnum ReadAsPropertyName(
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
            return new ActionBindingTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ActionBindingTypeEnum value,
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
        public const string TriggerBound = "trigger-bound";

        public const string EntityBound = "entity-bound";
    }
}
