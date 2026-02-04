namespace Auth0.ManagementApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class ContentTooLargeError(object body)
    : ManagementApiException("ContentTooLargeError", 413, body);
