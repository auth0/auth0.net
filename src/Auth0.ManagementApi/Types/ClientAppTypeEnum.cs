using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(ClientAppTypeEnum.ClientAppTypeEnumSerializer))]
[Serializable]
public readonly record struct ClientAppTypeEnum : IStringEnum
{
    public static readonly ClientAppTypeEnum Native = new(Values.Native);

    public static readonly ClientAppTypeEnum Spa = new(Values.Spa);

    public static readonly ClientAppTypeEnum RegularWeb = new(Values.RegularWeb);

    public static readonly ClientAppTypeEnum NonInteractive = new(Values.NonInteractive);

    public static readonly ClientAppTypeEnum ResourceServer = new(Values.ResourceServer);

    public static readonly ClientAppTypeEnum ExpressConfiguration = new(
        Values.ExpressConfiguration
    );

    public static readonly ClientAppTypeEnum Rms = new(Values.Rms);

    public static readonly ClientAppTypeEnum Box = new(Values.Box);

    public static readonly ClientAppTypeEnum Cloudbees = new(Values.Cloudbees);

    public static readonly ClientAppTypeEnum Concur = new(Values.Concur);

    public static readonly ClientAppTypeEnum Dropbox = new(Values.Dropbox);

    public static readonly ClientAppTypeEnum Mscrm = new(Values.Mscrm);

    public static readonly ClientAppTypeEnum Echosign = new(Values.Echosign);

    public static readonly ClientAppTypeEnum Egnyte = new(Values.Egnyte);

    public static readonly ClientAppTypeEnum Newrelic = new(Values.Newrelic);

    public static readonly ClientAppTypeEnum Office365 = new(Values.Office365);

    public static readonly ClientAppTypeEnum Salesforce = new(Values.Salesforce);

    public static readonly ClientAppTypeEnum Sentry = new(Values.Sentry);

    public static readonly ClientAppTypeEnum Sharepoint = new(Values.Sharepoint);

    public static readonly ClientAppTypeEnum Slack = new(Values.Slack);

    public static readonly ClientAppTypeEnum Springcm = new(Values.Springcm);

    public static readonly ClientAppTypeEnum Zendesk = new(Values.Zendesk);

    public static readonly ClientAppTypeEnum Zoom = new(Values.Zoom);

    public static readonly ClientAppTypeEnum SsoIntegration = new(Values.SsoIntegration);

    public static readonly ClientAppTypeEnum Oag = new(Values.Oag);

    public ClientAppTypeEnum(string value)
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
    public static ClientAppTypeEnum FromCustom(string value)
    {
        return new ClientAppTypeEnum(value);
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

    public static bool operator ==(ClientAppTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ClientAppTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ClientAppTypeEnum value) => value.Value;

    public static explicit operator ClientAppTypeEnum(string value) => new(value);

    internal class ClientAppTypeEnumSerializer : JsonConverter<ClientAppTypeEnum>
    {
        public override ClientAppTypeEnum Read(
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
            return new ClientAppTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientAppTypeEnum value,
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
        public const string Native = "native";

        public const string Spa = "spa";

        public const string RegularWeb = "regular_web";

        public const string NonInteractive = "non_interactive";

        public const string ResourceServer = "resource_server";

        public const string ExpressConfiguration = "express_configuration";

        public const string Rms = "rms";

        public const string Box = "box";

        public const string Cloudbees = "cloudbees";

        public const string Concur = "concur";

        public const string Dropbox = "dropbox";

        public const string Mscrm = "mscrm";

        public const string Echosign = "echosign";

        public const string Egnyte = "egnyte";

        public const string Newrelic = "newrelic";

        public const string Office365 = "office365";

        public const string Salesforce = "salesforce";

        public const string Sentry = "sentry";

        public const string Sharepoint = "sharepoint";

        public const string Slack = "slack";

        public const string Springcm = "springcm";

        public const string Zendesk = "zendesk";

        public const string Zoom = "zoom";

        public const string SsoIntegration = "sso_integration";

        public const string Oag = "oag";
    }
}
