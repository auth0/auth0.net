using System.IO;

#if MANAGEMENT_API
namespace Auth0.ManagementApi.Client.Models
#elif AUTHENTICATION_API
namespace Auth0.AuthenticationApi.Client.Models
#endif
{
    public class FileUploadParameter
    {
        internal string Key { get; set; }
        internal string Filename { get; set; }
        internal Stream FileStream { get; set; }
    }
}