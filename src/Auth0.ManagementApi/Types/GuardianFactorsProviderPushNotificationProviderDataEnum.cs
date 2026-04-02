using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(GuardianFactorsProviderPushNotificationProviderDataEnum.GuardianFactorsProviderPushNotificationProviderDataEnumSerializer)
)]
[Serializable]
public readonly record struct GuardianFactorsProviderPushNotificationProviderDataEnum : IStringEnum
{
    public static readonly GuardianFactorsProviderPushNotificationProviderDataEnum Guardian = new(
        Values.Guardian
    );

    public static readonly GuardianFactorsProviderPushNotificationProviderDataEnum Sns = new(
        Values.Sns
    );

    public static readonly GuardianFactorsProviderPushNotificationProviderDataEnum Direct = new(
        Values.Direct
    );

    public GuardianFactorsProviderPushNotificationProviderDataEnum(string value)
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
    public static GuardianFactorsProviderPushNotificationProviderDataEnum FromCustom(string value)
    {
        return new GuardianFactorsProviderPushNotificationProviderDataEnum(value);
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
        GuardianFactorsProviderPushNotificationProviderDataEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        GuardianFactorsProviderPushNotificationProviderDataEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        GuardianFactorsProviderPushNotificationProviderDataEnum value
    ) => value.Value;

    public static explicit operator GuardianFactorsProviderPushNotificationProviderDataEnum(
        string value
    ) => new(value);

    internal class GuardianFactorsProviderPushNotificationProviderDataEnumSerializer
        : JsonConverter<GuardianFactorsProviderPushNotificationProviderDataEnum>
    {
        public override GuardianFactorsProviderPushNotificationProviderDataEnum Read(
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
            return new GuardianFactorsProviderPushNotificationProviderDataEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GuardianFactorsProviderPushNotificationProviderDataEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GuardianFactorsProviderPushNotificationProviderDataEnum ReadAsPropertyName(
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
            return new GuardianFactorsProviderPushNotificationProviderDataEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GuardianFactorsProviderPushNotificationProviderDataEnum value,
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
        public const string Guardian = "guardian";

        public const string Sns = "sns";

        public const string Direct = "direct";
    }
}
