using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowActionWhatsappSendMessageParamsType>))]
[Serializable]
public readonly record struct FlowActionWhatsappSendMessageParamsType : IStringEnum
{
    public static readonly FlowActionWhatsappSendMessageParamsType Audio = new(Values.Audio);

    public static readonly FlowActionWhatsappSendMessageParamsType Contacts = new(Values.Contacts);

    public static readonly FlowActionWhatsappSendMessageParamsType Document = new(Values.Document);

    public static readonly FlowActionWhatsappSendMessageParamsType Image = new(Values.Image);

    public static readonly FlowActionWhatsappSendMessageParamsType Interactive = new(
        Values.Interactive
    );

    public static readonly FlowActionWhatsappSendMessageParamsType Location = new(Values.Location);

    public static readonly FlowActionWhatsappSendMessageParamsType Sticker = new(Values.Sticker);

    public static readonly FlowActionWhatsappSendMessageParamsType Template = new(Values.Template);

    public static readonly FlowActionWhatsappSendMessageParamsType Text = new(Values.Text);

    public FlowActionWhatsappSendMessageParamsType(string value)
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
    public static FlowActionWhatsappSendMessageParamsType FromCustom(string value)
    {
        return new FlowActionWhatsappSendMessageParamsType(value);
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

    public static bool operator ==(FlowActionWhatsappSendMessageParamsType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionWhatsappSendMessageParamsType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionWhatsappSendMessageParamsType value) =>
        value.Value;

    public static explicit operator FlowActionWhatsappSendMessageParamsType(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Audio = "AUDIO";

        public const string Contacts = "CONTACTS";

        public const string Document = "DOCUMENT";

        public const string Image = "IMAGE";

        public const string Interactive = "INTERACTIVE";

        public const string Location = "LOCATION";

        public const string Sticker = "STICKER";

        public const string Template = "TEMPLATE";

        public const string Text = "TEXT";
    }
}
