using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models;

public class BrandingTheme : BrandingThemeBase
{
    /// <summary>
    /// Theme ID
    /// </summary>
    [JsonProperty("themeId")]
    public string ThemeId { get; set; }
}

public class BrandingThemeCreateRequest : BrandingThemeBase
{
        
}
    
public class BrandingThemeUpdateRequest : BrandingThemeBase
{
        
}