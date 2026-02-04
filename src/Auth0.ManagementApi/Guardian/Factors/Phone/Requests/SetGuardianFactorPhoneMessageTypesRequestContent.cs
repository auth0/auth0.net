using System.Text.Json.Serialization;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Guardian.Factors;

[Serializable]
public record SetGuardianFactorPhoneMessageTypesRequestContent
{
    /// <summary>
    /// The list of phone factors to enable on the tenant. Can include `sms` and `voice`.
    /// </summary>
    [JsonPropertyName("message_types")]
    public IEnumerable<GuardianFactorPhoneFactorMessageTypeEnum> MessageTypes { get; set; } =
        new List<GuardianFactorPhoneFactorMessageTypeEnum>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
