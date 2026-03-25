using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FormWidgetTypeGMapsAddressConst.FormWidgetTypeGMapsAddressConstSerializer))]
[Serializable]
public readonly record struct FormWidgetTypeGMapsAddressConst : IStringEnum
{
    public static readonly FormWidgetTypeGMapsAddressConst GmapsAddress = new(Values.GmapsAddress);

    public FormWidgetTypeGMapsAddressConst(string value)
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
    public static FormWidgetTypeGMapsAddressConst FromCustom(string value)
    {
        return new FormWidgetTypeGMapsAddressConst(value);
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

    public static bool operator ==(FormWidgetTypeGMapsAddressConst value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FormWidgetTypeGMapsAddressConst value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FormWidgetTypeGMapsAddressConst value) => value.Value;

    public static explicit operator FormWidgetTypeGMapsAddressConst(string value) => new(value);

    internal class FormWidgetTypeGMapsAddressConstSerializer
        : JsonConverter<FormWidgetTypeGMapsAddressConst>
    {
        public override FormWidgetTypeGMapsAddressConst Read(
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
            return new FormWidgetTypeGMapsAddressConst(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FormWidgetTypeGMapsAddressConst value,
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
        public const string GmapsAddress = "GMAPS_ADDRESS";
    }
}
