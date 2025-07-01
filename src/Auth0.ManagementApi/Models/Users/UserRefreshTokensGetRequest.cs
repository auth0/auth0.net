namespace Auth0.ManagementApi.Models.Users;

/// <summary>
/// Represents the information required to Get User Refresh Tokens
/// </summary>
public class UserRefreshTokensGetRequest
{
    /// <summary>
    /// Id of the user to get refresh tokens for
    /// </summary>
    public string UserId { get; set; }
}