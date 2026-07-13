using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionUpdatedObject7OptionsIdentityApiEnum.EventStreamCloudEventConnectionUpdatedObject7OptionsIdentityApiEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionUpdatedObject7OptionsIdentityApiEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionUpdatedObject7OptionsIdentityApiEnum MicrosoftIdentityPlatformV20 =
        new(Values.MicrosoftIdentityPlatformV20);

    public static readonly EventStreamCloudEventConnectionUpdatedObject7OptionsIdentityApiEnum AzureActiveDirectoryV10 =
        new(Values.AzureActiveDirectoryV10);

    public EventStreamCloudEventConnectionUpdatedObject7OptionsIdentityApiEnum(string value)
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
    public static EventStreamCloudEventConnectionUpdatedObject7OptionsIdentityApiEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionUpdatedObject7OptionsIdentityApiEnum(value);
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
        EventStreamCloudEventConnectionUpdatedObject7OptionsIdentityApiEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionUpdatedObject7OptionsIdentityApiEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionUpdatedObject7OptionsIdentityApiEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionUpdatedObject7OptionsIdentityApiEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionUpdatedObject7OptionsIdentityApiEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionUpdatedObject7OptionsIdentityApiEnum>
    {
        public override EventStreamCloudEventConnectionUpdatedObject7OptionsIdentityApiEnum Read(
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
            return new EventStreamCloudEventConnectionUpdatedObject7OptionsIdentityApiEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionUpdatedObject7OptionsIdentityApiEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionUpdatedObject7OptionsIdentityApiEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionUpdatedObject7OptionsIdentityApiEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionUpdatedObject7OptionsIdentityApiEnum value,
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
        public const string MicrosoftIdentityPlatformV20 = "microsoft-identity-platform-v2.0";

        public const string AzureActiveDirectoryV10 = "azure-active-directory-v1.0";
    }
}
