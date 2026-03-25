using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionAuth0CreateUserType.FlowActionAuth0CreateUserTypeSerializer))]
[Serializable]
public readonly record struct FlowActionAuth0CreateUserType : IStringEnum
{
    public static readonly FlowActionAuth0CreateUserType Auth0 = new(Values.Auth0);

    public FlowActionAuth0CreateUserType(string value)
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
    public static FlowActionAuth0CreateUserType FromCustom(string value)
    {
        return new FlowActionAuth0CreateUserType(value);
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

    public static bool operator ==(FlowActionAuth0CreateUserType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionAuth0CreateUserType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionAuth0CreateUserType value) => value.Value;

    public static explicit operator FlowActionAuth0CreateUserType(string value) => new(value);

    internal class FlowActionAuth0CreateUserTypeSerializer
        : JsonConverter<FlowActionAuth0CreateUserType>
    {
        public override FlowActionAuth0CreateUserType Read(
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
            return new FlowActionAuth0CreateUserType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionAuth0CreateUserType value,
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
