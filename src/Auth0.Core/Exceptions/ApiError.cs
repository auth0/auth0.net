using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Auth0.Core.Serialization;

namespace Auth0.Core.Exceptions;

/// <summary>
/// Error information captured from a failed API request.
/// </summary>
[JsonConverter(typeof(ApiErrorConverter))]
public class ApiError
{
    /// <summary>
    /// Description of the failing HTTP Status Code.
    /// </summary>
    [JsonPropertyName("error")]
    public string? Error { get; set; }

    /// <summary>
    /// Error code returned by the API.
    /// </summary>
    [JsonPropertyName("errorCode")]
    public string? ErrorCode { get; set; }

    /// <summary>
    /// Description of the error.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    /// <summary>
    /// Additional key/values that might be returned by the error such as `mfa_required`.
    /// </summary>
    [JsonPropertyName("extraData")]
    public Dictionary<string, string> ExtraData { get; set; } = new();

    /// <summary>
    /// Parse a <see cref="HttpResponseMessage"/> into an <see cref="ApiError"/> asynchronously.
    /// </summary>
    /// <param name="response"><see cref="HttpResponseMessage"/> to parse.</param>
    /// <returns><see cref="Task"/> representing the operation and associated <see cref="ApiError"/> on
    /// successful completion.</returns>
    public static async Task<ApiError?> Parse(HttpResponseMessage? response)
    {
        if (response == null || response.Content == null)
            return null;

        var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        return Parse(content);
    }

    internal static ApiError? Parse(string? content)
    {
        if (string.IsNullOrWhiteSpace(content))
        {
            return null;
        }

        try
        {
            return JsonSerializer.Deserialize<ApiError>(content!, Auth0JsonSerializerOptions.Default);
        }
        // JsonException: malformed JSON. InvalidOperationException: valid JSON whose root is
        // not an object (e.g. a bare string or array), which the converter cannot enumerate.
        // Both fall back to surfacing the raw body.
        catch (System.Exception ex) when (ex is JsonException or System.InvalidOperationException)
        {
            return new ApiError
            {
                Error = content,
                Message = content
            };
        }
    }
}
