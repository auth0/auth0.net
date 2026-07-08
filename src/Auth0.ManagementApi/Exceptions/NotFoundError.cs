namespace Auth0.ManagementApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class NotFoundError(object body, Auth0.ManagementApi.RawResponse? rawResponse = null)
    : ManagementApiException("NotFoundError", 404, body, rawResponse: rawResponse);
