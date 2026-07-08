using System.Text.Json.Serialization;

namespace Auth0.AuthenticationApi.Models;

/// <summary>
/// Base class for user maintenance requests.
/// </summary>
public class UserMaintenanceRequestBase
{
    /// <summary>
    /// Client ID of the application.
    /// </summary>
    [JsonPropertyName("client_id")]
    public string ClientId { get; set; }

    /// <summary>
    /// Name of the connection.
    /// </summary>
    [JsonPropertyName("connection")]
    public string Connection { get; set; }

    /// <summary>
    /// Email address of the user.
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; }
}