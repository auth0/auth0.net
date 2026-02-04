using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record DeleteUserBlocksByIdentifierRequestParameters
{
    /// <summary>
    /// Should be any of a username, phone number, or email.
    /// </summary>
    [JsonIgnore]
    public required string Identifier { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
