using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionAuth0UpdateUserAction.FlowActionAuth0UpdateUserActionSerializer))]
[Serializable]
public readonly record struct FlowActionAuth0UpdateUserAction : IStringEnum
{
    public static readonly FlowActionAuth0UpdateUserAction UpdateUser = new(Values.UpdateUser);

    public FlowActionAuth0UpdateUserAction(string value)
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
    public static FlowActionAuth0UpdateUserAction FromCustom(string value)
    {
        return new FlowActionAuth0UpdateUserAction(value);
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

    public static bool operator ==(FlowActionAuth0UpdateUserAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionAuth0UpdateUserAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionAuth0UpdateUserAction value) => value.Value;

    public static explicit operator FlowActionAuth0UpdateUserAction(string value) => new(value);

    internal class FlowActionAuth0UpdateUserActionSerializer
        : JsonConverter<FlowActionAuth0UpdateUserAction>
    {
        public override FlowActionAuth0UpdateUserAction Read(
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
            return new FlowActionAuth0UpdateUserAction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionAuth0UpdateUserAction value,
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
        public const string UpdateUser = "UPDATE_USER";
    }
}
