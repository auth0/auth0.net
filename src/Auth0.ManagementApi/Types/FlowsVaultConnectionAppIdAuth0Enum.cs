using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowsVaultConnectionAppIdAuth0Enum.FlowsVaultConnectionAppIdAuth0EnumSerializer)
)]
[Serializable]
public readonly record struct FlowsVaultConnectionAppIdAuth0Enum : IStringEnum
{
    public static readonly FlowsVaultConnectionAppIdAuth0Enum Auth0 = new(Values.Auth0);

    public FlowsVaultConnectionAppIdAuth0Enum(string value)
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
    public static FlowsVaultConnectionAppIdAuth0Enum FromCustom(string value)
    {
        return new FlowsVaultConnectionAppIdAuth0Enum(value);
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

    public static bool operator ==(FlowsVaultConnectionAppIdAuth0Enum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowsVaultConnectionAppIdAuth0Enum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowsVaultConnectionAppIdAuth0Enum value) => value.Value;

    public static explicit operator FlowsVaultConnectionAppIdAuth0Enum(string value) => new(value);

    internal class FlowsVaultConnectionAppIdAuth0EnumSerializer
        : JsonConverter<FlowsVaultConnectionAppIdAuth0Enum>
    {
        public override FlowsVaultConnectionAppIdAuth0Enum Read(
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
            return new FlowsVaultConnectionAppIdAuth0Enum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowsVaultConnectionAppIdAuth0Enum value,
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
        public const string Auth0 = "AUTH0";
    }
}
