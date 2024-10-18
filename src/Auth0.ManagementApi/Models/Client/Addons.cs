using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    // TODO: Ensure list of addons are up to date

    /// <summary>
    /// Addons are extensions associated with an Application in Auth0. Usually, they are 3rd party APIs used by the app that Auth0 generates access tokens for 
    /// (e.g. Salesforce, Azure Service Bus, Azure Mobile Services, SAP, etc).
    /// </summary>
    public class Addons
    {
        /// <summary>
        /// Settings for Amazon Web Services Addon
        /// </summary>
        [JsonProperty("aws")]
        public dynamic AmazonWebServices { get; set; }

        /// <summary>
        /// Settings for Azure Mobile Services Addon
        /// </summary>
        [JsonProperty("wams")]
        public dynamic AzureMobileServices { get; set; }

        /// <summary>
        /// Settings for Azure Service Bus Addon
        /// </summary>
        [JsonProperty("azure_sb")]
        public dynamic AzureServiceBus { get; set; }

        /// <summary>
        /// Settings for Box Addon
        /// </summary>
        [JsonProperty("box")]
        public dynamic Box { get; set; }

        /// <summary>
        /// Settings for CloudBees Addon
        /// </summary>
        [JsonProperty("cloudbees")]
        public dynamic CloudBees { get; set; }

        /// <summary>
        /// Settings for Concur Addon
        /// </summary>
        [JsonProperty("concur")]
        public dynamic Concur { get; set; }

        /// <summary>
        /// Settings for Dropbox Addon
        /// </summary>
        [JsonProperty("dropbox")]
        public dynamic DropBox { get; set; }

        /// <summary>
        /// Settings for EchoSign Addon
        /// </summary>
        [JsonProperty("echosign")]
        public dynamic EchoSign { get; set; }

        /// <summary>
        /// Settings for Egnyte Addon
        /// </summary>
        [JsonProperty("egnyte")]
        public dynamic Egnyte { get; set; }

        /// <summary>
        /// Settings for Firebase Addon
        /// </summary>
        [JsonProperty("firebase")]
        public dynamic FireBase { get; set; }

        /// <summary>
        /// Settings for New Relic Addon
        /// </summary>
        [JsonProperty("newrelic")]
        public dynamic NewRelic { get; set; }

        /// <summary>
        /// Settings for Office 365 Addon
        /// </summary>
        [JsonProperty("office365")]
        public dynamic Office365 { get; set; }

        /// <summary>
        /// Settings for Salesforce Addon
        /// </summary>
        [JsonProperty("salesforce")]
        public dynamic SalesForce { get; set; }

        /// <summary>
        /// Settings for Salesforce API Addon
        /// </summary>
        [JsonProperty("salesforce_api")]
        public dynamic SalesForceApi { get; set; }

        /// <summary>
        /// Settings for Salesforce Sandbox API Addon
        /// </summary>
        [JsonProperty("salesforce_sandbox_api")]
        public dynamic SalesForceSandboxApi { get; set; }

        /// <summary>
        /// Settings for SAML2 Addon
        /// </summary>
        [JsonProperty("samlp")]
        public dynamic SamlP { get; set; }

        /// <summary>
        /// Settings for SAP API Addon
        /// </summary>
        [JsonProperty("sap_api")]
        public dynamic SapApi { get; set; }

        /// <summary>
        /// Settings for Sharepoint Addon
        /// </summary>
        [JsonProperty("sharepoint")]
        public dynamic SharePoint { get; set; }

        /// <summary>
        /// Settings for SpringCM Addon
        /// </summary>
        [JsonProperty("springcm")]
        // ReSharper disable once InconsistentNaming
        public dynamic SpringCM { get; set; }

        /// <summary>
        /// Settings for Web API Addon
        /// </summary>
        [JsonProperty("webapi")]
        public dynamic WebApi { get; set; }

        /// <summary>
        /// Settings for WS-FED Addon
        /// </summary>
        [JsonProperty("wsfed")]
        public dynamic WsFed { get; set; }

        /// <summary>
        /// Settings for Zendesk Addon
        /// </summary>
        [JsonProperty("zendesk")]
        public dynamic Zendesk { get; set; }

        /// <summary>
        /// Settings for Zoom Addon
        /// </summary>
        [JsonProperty("zoom")]
        public dynamic Zoom { get; set; }
    }
}