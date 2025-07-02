using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using Auth0.ManagementApi.Paging;

namespace Auth0.ManagementApi.Models.Forms;

public class FormsGetRequest
{
    public PaginationInfo PaginationInfo { get; set; }
        
    /// <summary>
    /// Hydration parameter
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public Hydrate[] Hydrate { get; set; }
        
    /// <summary>
    /// Form Identifier
    /// </summary>
    public string Id { get; set; }
}