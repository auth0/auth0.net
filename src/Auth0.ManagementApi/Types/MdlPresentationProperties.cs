using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record MdlPresentationProperties : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// Family Name
    /// </summary>
    [Optional]
    [JsonPropertyName("family_name")]
    public bool? FamilyName { get; set; }

    /// <summary>
    /// Given Name
    /// </summary>
    [Optional]
    [JsonPropertyName("given_name")]
    public bool? GivenName { get; set; }

    /// <summary>
    /// Birth Date
    /// </summary>
    [Optional]
    [JsonPropertyName("birth_date")]
    public bool? BirthDate { get; set; }

    /// <summary>
    /// Issue Date
    /// </summary>
    [Optional]
    [JsonPropertyName("issue_date")]
    public bool? IssueDate { get; set; }

    /// <summary>
    /// Expiry Date
    /// </summary>
    [Optional]
    [JsonPropertyName("expiry_date")]
    public bool? ExpiryDate { get; set; }

    /// <summary>
    /// Issuing Country
    /// </summary>
    [Optional]
    [JsonPropertyName("issuing_country")]
    public bool? IssuingCountry { get; set; }

    /// <summary>
    /// Issuing Authority
    /// </summary>
    [Optional]
    [JsonPropertyName("issuing_authority")]
    public bool? IssuingAuthority { get; set; }

    /// <summary>
    /// Portrait
    /// </summary>
    [Optional]
    [JsonPropertyName("portrait")]
    public bool? Portrait { get; set; }

    /// <summary>
    /// Driving Privileges
    /// </summary>
    [Optional]
    [JsonPropertyName("driving_privileges")]
    public bool? DrivingPrivileges { get; set; }

    /// <summary>
    /// Resident Address
    /// </summary>
    [Optional]
    [JsonPropertyName("resident_address")]
    public bool? ResidentAddress { get; set; }

    /// <summary>
    /// Portrait Capture Date
    /// </summary>
    [Optional]
    [JsonPropertyName("portrait_capture_date")]
    public bool? PortraitCaptureDate { get; set; }

    /// <summary>
    /// Age in Years
    /// </summary>
    [Optional]
    [JsonPropertyName("age_in_years")]
    public bool? AgeInYears { get; set; }

    /// <summary>
    /// Age Birth Year
    /// </summary>
    [Optional]
    [JsonPropertyName("age_birth_year")]
    public bool? AgeBirthYear { get; set; }

    /// <summary>
    /// Issuing Jurisdiction
    /// </summary>
    [Optional]
    [JsonPropertyName("issuing_jurisdiction")]
    public bool? IssuingJurisdiction { get; set; }

    /// <summary>
    /// Nationality
    /// </summary>
    [Optional]
    [JsonPropertyName("nationality")]
    public bool? Nationality { get; set; }

    /// <summary>
    /// Resident City
    /// </summary>
    [Optional]
    [JsonPropertyName("resident_city")]
    public bool? ResidentCity { get; set; }

    /// <summary>
    /// Resident State
    /// </summary>
    [Optional]
    [JsonPropertyName("resident_state")]
    public bool? ResidentState { get; set; }

    /// <summary>
    /// Resident Postal Code
    /// </summary>
    [Optional]
    [JsonPropertyName("resident_postal_code")]
    public bool? ResidentPostalCode { get; set; }

    /// <summary>
    /// Resident Country
    /// </summary>
    [Optional]
    [JsonPropertyName("resident_country")]
    public bool? ResidentCountry { get; set; }

    /// <summary>
    /// Family Name National Character
    /// </summary>
    [Optional]
    [JsonPropertyName("family_name_national_character")]
    public bool? FamilyNameNationalCharacter { get; set; }

    /// <summary>
    /// Given Name National Character
    /// </summary>
    [Optional]
    [JsonPropertyName("given_name_national_character")]
    public bool? GivenNameNationalCharacter { get; set; }

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
