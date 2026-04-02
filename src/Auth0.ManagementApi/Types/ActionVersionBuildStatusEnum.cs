using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(ActionVersionBuildStatusEnum.ActionVersionBuildStatusEnumSerializer))]
[Serializable]
public readonly record struct ActionVersionBuildStatusEnum : IStringEnum
{
    public static readonly ActionVersionBuildStatusEnum Pending = new(Values.Pending);

    public static readonly ActionVersionBuildStatusEnum Building = new(Values.Building);

    public static readonly ActionVersionBuildStatusEnum Packaged = new(Values.Packaged);

    public static readonly ActionVersionBuildStatusEnum Built = new(Values.Built);

    public static readonly ActionVersionBuildStatusEnum Retrying = new(Values.Retrying);

    public static readonly ActionVersionBuildStatusEnum Failed = new(Values.Failed);

    public ActionVersionBuildStatusEnum(string value)
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
    public static ActionVersionBuildStatusEnum FromCustom(string value)
    {
        return new ActionVersionBuildStatusEnum(value);
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

    public static bool operator ==(ActionVersionBuildStatusEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ActionVersionBuildStatusEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ActionVersionBuildStatusEnum value) => value.Value;

    public static explicit operator ActionVersionBuildStatusEnum(string value) => new(value);

    internal class ActionVersionBuildStatusEnumSerializer
        : JsonConverter<ActionVersionBuildStatusEnum>
    {
        public override ActionVersionBuildStatusEnum Read(
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
            return new ActionVersionBuildStatusEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ActionVersionBuildStatusEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ActionVersionBuildStatusEnum ReadAsPropertyName(
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
            return new ActionVersionBuildStatusEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ActionVersionBuildStatusEnum value,
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
        public const string Pending = "pending";

        public const string Building = "building";

        public const string Packaged = "packaged";

        public const string Built = "built";

        public const string Retrying = "retrying";

        public const string Failed = "failed";
    }
}
