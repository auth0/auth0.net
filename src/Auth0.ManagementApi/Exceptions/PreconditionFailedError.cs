namespace Auth0.ManagementApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class PreconditionFailedError(
    object body,
    Auth0.ManagementApi.RawResponse? rawResponse = null
) : ManagementApiException("PreconditionFailedError", 412, body, rawResponse: rawResponse);
