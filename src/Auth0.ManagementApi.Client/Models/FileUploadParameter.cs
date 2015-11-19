using System.IO;

namespace Auth0.ManagementApi.Client.Models
{
    public class FileUploadParameter
    {
        internal string Key { get; set; }
        internal string Filename { get; set; }
        internal Stream FileStream { get; set; }
    }
}