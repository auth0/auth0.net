using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(HookTriggerIdEnum.HookTriggerIdEnumSerializer))]
[Serializable]
public readonly record struct HookTriggerIdEnum : IStringEnum
{
    public static readonly HookTriggerIdEnum CredentialsExchange = new(Values.CredentialsExchange);

    public static readonly HookTriggerIdEnum PreUserRegistration = new(Values.PreUserRegistration);

    public static readonly HookTriggerIdEnum PostUserRegistration = new(
        Values.PostUserRegistration
    );

    public static readonly HookTriggerIdEnum PostChangePassword = new(Values.PostChangePassword);

    public static readonly HookTriggerIdEnum SendPhoneMessage = new(Values.SendPhoneMessage);

    public HookTriggerIdEnum(string value)
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
    public static HookTriggerIdEnum FromCustom(string value)
    {
        return new HookTriggerIdEnum(value);
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

    public static bool operator ==(HookTriggerIdEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(HookTriggerIdEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(HookTriggerIdEnum value) => value.Value;

    public static explicit operator HookTriggerIdEnum(string value) => new(value);

    internal class HookTriggerIdEnumSerializer : JsonConverter<HookTriggerIdEnum>
    {
        public override HookTriggerIdEnum Read(
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
            return new HookTriggerIdEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            HookTriggerIdEnum value,
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
        public const string CredentialsExchange = "credentials-exchange";

        public const string PreUserRegistration = "pre-user-registration";

        public const string PostUserRegistration = "post-user-registration";

        public const string PostChangePassword = "post-change-password";

        public const string SendPhoneMessage = "send-phone-message";
    }
}
