using System.IO;

namespace Auth0.Core.Http
{

    /// <summary>
    /// 
    /// </summary>
    public class FileUploadParameter
    {
        //TODO: RWM: See if it is possible to make this class internal. It's used by an interface so I don't know if it can be.

        internal string Key { get; set; }
        internal string Filename { get; set; }
        internal Stream FileStream { get; set; }

    }

}