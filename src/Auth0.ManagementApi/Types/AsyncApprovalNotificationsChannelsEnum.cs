using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(AsyncApprovalNotificationsChannelsEnum.AsyncApprovalNotificationsChannelsEnumSerializer)
)]
[Serializable]
public readonly record struct AsyncApprovalNotificationsChannelsEnum : IStringEnum
{
    public static readonly AsyncApprovalNotificationsChannelsEnum GuardianPush = new(
        Values.GuardianPush
    );

    public static readonly AsyncApprovalNotificationsChannelsEnum Email = new(Values.Email);

    public AsyncApprovalNotificationsChannelsEnum(string value)
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
    public static AsyncApprovalNotificationsChannelsEnum FromCustom(string value)
    {
        return new AsyncApprovalNotificationsChannelsEnum(value);
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

    public static bool operator ==(AsyncApprovalNotificationsChannelsEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AsyncApprovalNotificationsChannelsEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AsyncApprovalNotificationsChannelsEnum value) =>
        value.Value;

    public static explicit operator AsyncApprovalNotificationsChannelsEnum(string value) =>
        new(value);

    internal class AsyncApprovalNotificationsChannelsEnumSerializer
        : JsonConverter<AsyncApprovalNotificationsChannelsEnum>
    {
        public override AsyncApprovalNotificationsChannelsEnum Read(
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
            return new AsyncApprovalNotificationsChannelsEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AsyncApprovalNotificationsChannelsEnum value,
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
        public const string GuardianPush = "guardian-push";

        public const string Email = "email";
    }
}
