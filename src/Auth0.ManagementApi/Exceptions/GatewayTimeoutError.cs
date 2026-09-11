namespace Auth0.ManagementApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class GatewayTimeoutError(object body, Auth0.ManagementApi.RawResponse? rawResponse = null)
    : ManagementApiException("GatewayTimeoutError", 504, body, rawResponse: rawResponse);
