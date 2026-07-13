using global::System.Text.Json;

namespace Auth0.ManagementApi;

/// <summary>
/// Structured error information extracted from a failed Management API response body.
/// Only the well-known, non-sensitive error fields returned by the API are surfaced.
/// </summary>
public sealed class ApiError
{
    /// <summary>
    /// The short error identifier returned by the API (the <c>error</c> field), e.g. "Bad Request".
    /// </summary>
    public string? Error { get; init; }

    /// <summary>
    /// The machine-readable error code returned by the API (the <c>errorCode</c> field), if present.
    /// </summary>
    public string? ErrorCode { get; init; }

    /// <summary>
    /// The human-readable error description returned by the API. Populated from the first available
    /// of <c>message</c>, <c>error_description</c>, <c>description</c>, or <c>error</c>.
    /// </summary>
    public string? Message { get; init; }

    /// <summary>
    /// Attempts to build an <see cref="ApiError"/> from a response body. The body is expected to be the
    /// boxed <see cref="JsonElement"/> produced by the SDK when deserializing an error response.
    /// Returns <c>null</c> when no usable error information can be extracted.
    /// </summary>
    internal static ApiError? TryParse(object? body)
    {
        if (body is not JsonElement element || element.ValueKind != JsonValueKind.Object)
        {
            return null;
        }

        try
        {
            var error = GetString(element, "error");
            var errorCode = GetString(element, "errorCode") ?? GetString(element, "error_code");
            var message =
                GetString(element, "message")
                ?? GetString(element, "error_description")
                ?? GetString(element, "description")
                ?? error;

            if (error is null && errorCode is null && message is null)
            {
                return null;
            }

            return new ApiError
            {
                Error = error,
                ErrorCode = errorCode,
                Message = message,
            };
        }
        catch (Exception)
        {
            return null;
        }
    }

    private static string? GetString(JsonElement element, string propertyName)
    {
        if (
            element.TryGetProperty(propertyName, out var value)
            && value.ValueKind == JsonValueKind.String
        )
        {
            return value.GetString();
        }

        return null;
    }
}
