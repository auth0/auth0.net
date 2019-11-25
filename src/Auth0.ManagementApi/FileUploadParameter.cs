using System.IO;

namespace Auth0.Core.Http
{
    public class FileUploadParameter
    {
        internal string Key { get; set; }
        internal string Filename { get; set; }
        internal Stream FileStream { get; set; }
    }
}