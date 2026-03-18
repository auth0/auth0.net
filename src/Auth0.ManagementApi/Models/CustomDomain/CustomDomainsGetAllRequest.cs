namespace Auth0.ManagementApi.Models;

/// <summary>
/// Represents a request to retrieve all custom domains with optional filtering, field selection, and sorting.
/// </summary>
public class CustomDomainsGetAllRequest
{
    /// <summary>
    /// Query in <a href="http://www.lucenetutorial.com/lucene-query-syntax.html">Lucene query string syntax</a>.
    /// </summary>
    public string? Query { get; set; }
    
    /// <summary>
    /// Comma-separated list of fields to include or exclude
    /// (based on value provided for include_fields) in the result.
    /// Leave empty to retrieve all fields.
    /// </summary>
    public string? Fields { get; set; }
    
    /// <summary>
    /// Whether specified fields are to be included (true) or excluded (false).
    /// </summary>
    public bool? IncludeFields { get; set; } = null;
    
    /// <summary>
    /// Field to sort by.
    /// Only domain:1 (ascending order by domain) is supported at this time.
    /// </summary>
    public string? Sort { get; set; }
}