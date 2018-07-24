using System.Runtime.Serialization;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// The type of application for a <see cref="Client"/>
    /// </summary>
    public enum ClientApplicationType
    {
        /// <summary>
        /// Box (SSO)
        /// </summary>
        [EnumMember(Value = "box")]
        Box,

        /// <summary>
        /// Cloudbees (SSO)
        /// </summary>
        [EnumMember(Value = "cloudbees")]
        Cloudbees,

        /// <summary>
        /// Concur (SSO)
        /// </summary>
        [EnumMember(Value = "concur")]
        Concur,

        /// <summary>
        /// Dropbox (SSO)
        /// </summary>
        [EnumMember(Value = "dropbox")]
        Dropbox,

        /// <summary>
        /// Adobe Echosign (SSO)
        /// </summary>
        [EnumMember(Value = "echosign")]
        Echosign,

        /// <summary>
        /// Egnyte (SSO)
        /// </summary>
        [EnumMember(Value = "egnyte")]
        Egnyte,

        /// <summary>
        /// Microsoft Dynamics CRM (SSO)
        /// </summary>
        [EnumMember(Value = "mscrm")]
        MsCrm,

        /// <summary>
        /// Mobile or Desktop, apps that run natively in a device.
        /// </summary>
        [EnumMember(Value = "native")]
        Native,

        /// <summary>
        /// New Relic (SSO)
        /// </summary>
        [EnumMember(Value = "newrelic")]
        NewRelic,

        /// <summary>
        /// CLI, Daemons or Services running on your backend.
        /// </summary>
        [EnumMember(Value = "non_interactive")]
        NonInteractive,

        /// <summary>
        /// Office 365 (SSO)
        /// </summary>
        [EnumMember(Value = "office365")]
        Office365,

        /// <summary>
        /// Traditional web app (with refresh).
        /// </summary>
        [EnumMember(Value = "regular_web")]
        RegularWeb,

        /// <summary>
        /// Active Directory RMS (SSO)
        /// </summary>
        [EnumMember(Value = "rms")]
        Rms,

        /// <summary>
        /// Salesforce (SSO)
        /// </summary>
        [EnumMember(Value = "salesforce")]
        Salesforce,

        /// <summary>
        /// Sentry (SSO)
        /// </summary>
        [EnumMember(Value = "sentry")]
        Sentry,

        /// <summary>
        /// SharePoint (SSO)
        /// </summary>
        [EnumMember(Value = "sharepoint")]
        SharePoint,

        /// <summary>
        /// Slack (SSO)
        /// </summary>
        [EnumMember(Value = "slack")]
        Slack,

        /// <summary>
        /// SpringCM (SSO)
        /// </summary>
        [EnumMember(Value = "springcm")]
        SpringCm,

        /// <summary>
        /// A JavaScript front-end app that uses an API.
        /// </summary>
        [EnumMember(Value = "spa")]
        Spa,

        /// <summary>
        /// Zendesk (SSO)
        /// </summary>
        [EnumMember(Value = "zendesk")]
        Zendesk,

        /// <summary>
        /// Zoom (SSO)
        /// </summary>
        [EnumMember(Value = "zoom")]
        Zoom
    }
}