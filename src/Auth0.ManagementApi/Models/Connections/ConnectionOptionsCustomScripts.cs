using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Connections;

/// <summary>
/// A map of scripts used to integrate with a custom database.
/// </summary>
public class ConnectionOptionsCustomScripts
{
    [JsonProperty("login")]
    public string Login { get; set; }
        
    [JsonProperty("get_user")]
    public string GetUser { get; set; }
        
    [JsonProperty("delete")]
    public string Delete { get; set; }
        
    [JsonProperty("change_password")]
    public string ChangePassword { get; set; }
        
    [JsonProperty("verify")]
    public string Verify { get; set; }
        
    [JsonProperty("create")]
    public string Create { get; set; }
        
    [JsonProperty("change_username")]
    public string ChangeUsername { get; set; }
        
    [JsonProperty("change_email")]
    public string ChangeEmail { get; set; }
        
    [JsonProperty("change_phone_number")]
    public string ChangePhoneNumber { get; set; }
}