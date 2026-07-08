namespace Auth0.ManagementApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class ConflictError(object body, Auth0.ManagementApi.RawResponse? rawResponse = null)
    : ManagementApiException("ConflictError", 409, body, rawResponse: rawResponse);
