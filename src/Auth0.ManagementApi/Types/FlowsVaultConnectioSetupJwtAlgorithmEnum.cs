using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowsVaultConnectioSetupJwtAlgorithmEnum.FlowsVaultConnectioSetupJwtAlgorithmEnumSerializer)
)]
[Serializable]
public readonly record struct FlowsVaultConnectioSetupJwtAlgorithmEnum : IStringEnum
{
    public static readonly FlowsVaultConnectioSetupJwtAlgorithmEnum Hs256 = new(Values.Hs256);

    public static readonly FlowsVaultConnectioSetupJwtAlgorithmEnum Hs384 = new(Values.Hs384);

    public static readonly FlowsVaultConnectioSetupJwtAlgorithmEnum Hs512 = new(Values.Hs512);

    public static readonly FlowsVaultConnectioSetupJwtAlgorithmEnum Rs256 = new(Values.Rs256);

    public static readonly FlowsVaultConnectioSetupJwtAlgorithmEnum Rs384 = new(Values.Rs384);

    public static readonly FlowsVaultConnectioSetupJwtAlgorithmEnum Rs512 = new(Values.Rs512);

    public static readonly FlowsVaultConnectioSetupJwtAlgorithmEnum Es256 = new(Values.Es256);

    public static readonly FlowsVaultConnectioSetupJwtAlgorithmEnum Es384 = new(Values.Es384);

    public static readonly FlowsVaultConnectioSetupJwtAlgorithmEnum Es512 = new(Values.Es512);

    public static readonly FlowsVaultConnectioSetupJwtAlgorithmEnum Ps256 = new(Values.Ps256);

    public static readonly FlowsVaultConnectioSetupJwtAlgorithmEnum Ps384 = new(Values.Ps384);

    public static readonly FlowsVaultConnectioSetupJwtAlgorithmEnum Ps512 = new(Values.Ps512);

    public FlowsVaultConnectioSetupJwtAlgorithmEnum(string value)
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
    public static FlowsVaultConnectioSetupJwtAlgorithmEnum FromCustom(string value)
    {
        return new FlowsVaultConnectioSetupJwtAlgorithmEnum(value);
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
        FlowsVaultConnectioSetupJwtAlgorithmEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        FlowsVaultConnectioSetupJwtAlgorithmEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(FlowsVaultConnectioSetupJwtAlgorithmEnum value) =>
        value.Value;

    public static explicit operator FlowsVaultConnectioSetupJwtAlgorithmEnum(string value) =>
        new(value);

    internal class FlowsVaultConnectioSetupJwtAlgorithmEnumSerializer
        : JsonConverter<FlowsVaultConnectioSetupJwtAlgorithmEnum>
    {
        public override FlowsVaultConnectioSetupJwtAlgorithmEnum Read(
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
            return new FlowsVaultConnectioSetupJwtAlgorithmEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowsVaultConnectioSetupJwtAlgorithmEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowsVaultConnectioSetupJwtAlgorithmEnum ReadAsPropertyName(
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
            return new FlowsVaultConnectioSetupJwtAlgorithmEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowsVaultConnectioSetupJwtAlgorithmEnum value,
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
        public const string Hs256 = "HS256";

        public const string Hs384 = "HS384";

        public const string Hs512 = "HS512";

        public const string Rs256 = "RS256";

        public const string Rs384 = "RS384";

        public const string Rs512 = "RS512";

        public const string Es256 = "ES256";

        public const string Es384 = "ES384";

        public const string Es512 = "ES512";

        public const string Ps256 = "PS256";

        public const string Ps384 = "PS384";

        public const string Ps512 = "PS512";
    }
}
