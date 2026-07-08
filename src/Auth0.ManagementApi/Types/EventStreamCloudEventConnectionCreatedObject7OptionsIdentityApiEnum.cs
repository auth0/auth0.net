using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionCreatedObject7OptionsIdentityApiEnum.EventStreamCloudEventConnectionCreatedObject7OptionsIdentityApiEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionCreatedObject7OptionsIdentityApiEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionCreatedObject7OptionsIdentityApiEnum MicrosoftIdentityPlatformV20 =
        new(Values.MicrosoftIdentityPlatformV20);

    public static readonly EventStreamCloudEventConnectionCreatedObject7OptionsIdentityApiEnum AzureActiveDirectoryV10 =
        new(Values.AzureActiveDirectoryV10);

    public EventStreamCloudEventConnectionCreatedObject7OptionsIdentityApiEnum(string value)
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
    public static EventStreamCloudEventConnectionCreatedObject7OptionsIdentityApiEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionCreatedObject7OptionsIdentityApiEnum(value);
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
        EventStreamCloudEventConnectionCreatedObject7OptionsIdentityApiEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionCreatedObject7OptionsIdentityApiEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionCreatedObject7OptionsIdentityApiEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionCreatedObject7OptionsIdentityApiEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionCreatedObject7OptionsIdentityApiEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionCreatedObject7OptionsIdentityApiEnum>
    {
        public override EventStreamCloudEventConnectionCreatedObject7OptionsIdentityApiEnum Read(
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
            return new EventStreamCloudEventConnectionCreatedObject7OptionsIdentityApiEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedObject7OptionsIdentityApiEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionCreatedObject7OptionsIdentityApiEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionCreatedObject7OptionsIdentityApiEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedObject7OptionsIdentityApiEnum value,
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
