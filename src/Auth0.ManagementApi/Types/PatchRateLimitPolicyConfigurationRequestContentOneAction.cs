using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(PatchRateLimitPolicyConfigurationRequestContentOneAction.PatchRateLimitPolicyConfigurationRequestContentOneActionSerializer)
)]
[Serializable]
public readonly record struct PatchRateLimitPolicyConfigurationRequestContentOneAction : IStringEnum
{
    public static readonly PatchRateLimitPolicyConfigurationRequestContentOneAction Block = new(
        Values.Block
    );

    public static readonly PatchRateLimitPolicyConfigurationRequestContentOneAction Log = new(
        Values.Log
    );

    public PatchRateLimitPolicyConfigurationRequestContentOneAction(string value)
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
    public static PatchRateLimitPolicyConfigurationRequestContentOneAction FromCustom(string value)
    {
        return new PatchRateLimitPolicyConfigurationRequestContentOneAction(value);
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
        PatchRateLimitPolicyConfigurationRequestContentOneAction value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        PatchRateLimitPolicyConfigurationRequestContentOneAction value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        PatchRateLimitPolicyConfigurationRequestContentOneAction value
    ) => value.Value;

    public static explicit operator PatchRateLimitPolicyConfigurationRequestContentOneAction(
        string value
    ) => new(value);

    internal class PatchRateLimitPolicyConfigurationRequestContentOneActionSerializer
        : JsonConverter<PatchRateLimitPolicyConfigurationRequestContentOneAction>
    {
        public override PatchRateLimitPolicyConfigurationRequestContentOneAction Read(
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
            return new PatchRateLimitPolicyConfigurationRequestContentOneAction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PatchRateLimitPolicyConfigurationRequestContentOneAction value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PatchRateLimitPolicyConfigurationRequestContentOneAction ReadAsPropertyName(
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
            return new PatchRateLimitPolicyConfigurationRequestContentOneAction(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PatchRateLimitPolicyConfigurationRequestContentOneAction value,
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
        public const string Block = "block";

        public const string Log = "log";
    }
}
