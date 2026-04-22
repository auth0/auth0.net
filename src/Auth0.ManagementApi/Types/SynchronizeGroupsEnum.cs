using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(SynchronizeGroupsEnum.SynchronizeGroupsEnumSerializer))]
[Serializable]
public readonly record struct SynchronizeGroupsEnum : IStringEnum
{
    public static readonly SynchronizeGroupsEnum All = new(Values.All);

    public static readonly SynchronizeGroupsEnum Off = new(Values.Off);

    public static readonly SynchronizeGroupsEnum Selected = new(Values.Selected);

    public SynchronizeGroupsEnum(string value)
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
    public static SynchronizeGroupsEnum FromCustom(string value)
    {
        return new SynchronizeGroupsEnum(value);
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

    public static bool operator ==(SynchronizeGroupsEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SynchronizeGroupsEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SynchronizeGroupsEnum value) => value.Value;

    public static explicit operator SynchronizeGroupsEnum(string value) => new(value);

    internal class SynchronizeGroupsEnumSerializer : JsonConverter<SynchronizeGroupsEnum>
    {
        public override SynchronizeGroupsEnum Read(
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
            return new SynchronizeGroupsEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SynchronizeGroupsEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SynchronizeGroupsEnum ReadAsPropertyName(
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
            return new SynchronizeGroupsEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SynchronizeGroupsEnum value,
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
        public const string All = "all";

        public const string Off = "off";

        public const string Selected = "selected";
    }
}
