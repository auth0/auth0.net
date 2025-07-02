using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models.Actions;

/// <summary>
/// Integration defines a self-contained functioning unit which partners
/// publish. A partner may create one or many of these integrations.
/// </summary>
public class Integration
{
    /// <summary>
    /// id is a system generated GUID. This same ID is designed to be federated in
    /// all the applicable localities.
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }
        
    /// <summary>
    /// catalog_id refers to the ID in the marketplace catalog
    /// </summary>
    [JsonProperty("catalog_id")]
    public string CatalogId { get; set; }
        
    /// <summary>
    /// url_slug refers to the url_slug in the marketplace catalog
    /// </summary>
    [JsonProperty("url_slug")]
    public string UrlSlug { get; set; }
        
    /// <summary>
    /// partner_id is the foreign key reference to the partner account this
    /// integration belongs to.
    /// </summary>
    [JsonProperty("partner_id")]
    public string PartnerId { get; set; }
        
    /// <summary>
    /// name is the integration name, which will be used for display purposes in
    /// the marketplace.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }
                
    /// <summary>
    /// description adds more text for the integration name -- also relevant for
    /// the marketplace listing.
    /// </summary>
    [JsonProperty("description")]
    public string Description { get; set; }
        
    /// <summary>
    /// short_description is the brief description of the integration, which is used for display purposes in cards
    /// </summary>
    [JsonProperty("short_description")]
    public string ShortDescription { get; set; }
        
    [JsonProperty("logo")]
    public string Logo { get; set; }
        
    /// <summary>
    /// description adds more text for the integration name -- also relevant for
    /// the marketplace listing.
    /// </summary>
    [JsonProperty("feature_type")]
    [JsonConverter(typeof(StringEnumConverter))]
    public FeatureType FeatureType { get; set; }
        
    [JsonProperty("terms_of_use_url")]
    public string TermsOfUseUrl { get; set; }
        
    [JsonProperty("privacy_policy_url")]
    public string PrivacyPolicyUrl { get; set; }
        
    [JsonProperty("public_support_link")]
    public string PublicSupportLink { get; set; }
        
    [JsonProperty("current_release")]
    public CurrentRelease CurrentRelease { get; set; }
        
    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }
        
    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}