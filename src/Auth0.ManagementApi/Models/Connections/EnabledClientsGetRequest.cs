namespace Auth0.ManagementApi.Models.Connections;

/// <summary>
/// Contains information required to fetch <see cref="EnabledClients"/>. 
/// </summary>
public class EnabledClientsGetRequest
{
    /// <summary>
    /// The id of the connection for which enabled clients are to be retrieved
    /// </summary>
    public string ConnectionId { get; set; }
};