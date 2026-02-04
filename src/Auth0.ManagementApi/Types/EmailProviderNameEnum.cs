using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<EmailProviderNameEnum>))]
[Serializable]
public readonly record struct EmailProviderNameEnum : IStringEnum
{
    public static readonly EmailProviderNameEnum Mailgun = new(Values.Mailgun);

    public static readonly EmailProviderNameEnum Mandrill = new(Values.Mandrill);

    public static readonly EmailProviderNameEnum Sendgrid = new(Values.Sendgrid);

    public static readonly EmailProviderNameEnum Ses = new(Values.Ses);

    public static readonly EmailProviderNameEnum Sparkpost = new(Values.Sparkpost);

    public static readonly EmailProviderNameEnum Smtp = new(Values.Smtp);

    public static readonly EmailProviderNameEnum AzureCs = new(Values.AzureCs);

    public static readonly EmailProviderNameEnum Ms365 = new(Values.Ms365);

    public static readonly EmailProviderNameEnum Custom = new(Values.Custom);

    public EmailProviderNameEnum(string value)
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
    public static EmailProviderNameEnum FromCustom(string value)
    {
        return new EmailProviderNameEnum(value);
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

    public static bool operator ==(EmailProviderNameEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(EmailProviderNameEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EmailProviderNameEnum value) => value.Value;

    public static explicit operator EmailProviderNameEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Mailgun = "mailgun";

        public const string Mandrill = "mandrill";

        public const string Sendgrid = "sendgrid";

        public const string Ses = "ses";

        public const string Sparkpost = "sparkpost";

        public const string Smtp = "smtp";

        public const string AzureCs = "azure_cs";

        public const string Ms365 = "ms365";

        public const string Custom = "custom";
    }
}
