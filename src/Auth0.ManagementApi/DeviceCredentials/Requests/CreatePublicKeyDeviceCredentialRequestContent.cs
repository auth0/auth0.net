using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record CreatePublicKeyDeviceCredentialRequestContent
{
    /// <summary>
    /// Name for this device easily recognized by owner.
    /// </summary>
    [JsonPropertyName("device_name")]
    public required string DeviceName { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; } = "public_key";

    /// <summary>
    /// Base64 encoded string containing the credential.
    /// </summary>
    [JsonPropertyName("value")]
    public required string Value { get; set; }

    /// <summary>
    /// Unique identifier for the device. Recommend using <see href="http://developer.android.com/reference/android/provider/Settings.Secure.html#ANDROID_ID">Android_ID</see> on Android and <see href="https://developer.apple.com/library/ios/documentation/UIKit/Reference/UIDevice_Class/index.html#//apple_ref/occ/instp/UIDevice/identifierForVendor">identifierForVendor</see>.
    /// </summary>
    [JsonPropertyName("device_id")]
    public required string DeviceId { get; set; }

    /// <summary>
    /// client_id of the client (application) this credential is for.
    /// </summary>
    [Optional]
    [JsonPropertyName("client_id")]
    public string? ClientId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
