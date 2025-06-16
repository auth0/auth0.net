using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
 
    /// <summary>
    /// Contains information about the Jobs error status.
    /// </summary>
    public class JobError
    {
        /// <inheritdoc cref="JobImportErrorDetails"/>
        public JobImportErrorDetails[] JobImportErrorDetails { get; set; }
        
        /// <inheritdoc cref="JobErrorDetails"/>
        public JobErrorDetails JobErrorDetails { get; set; }
    }

    /// <summary>
    /// Contains details of the Job including the status and failure reason
    /// </summary>
    public class JobErrorDetails : Job
    {
        /// <summary>
        /// Status details.
        /// </summary>
        [JsonProperty("status_details")]
        public string StatusDetails { get; set; }
    }
    
    /// <summary>
    /// Contains information of the error that failed the job
    /// </summary>
    public class JobImportErrorDetails
    {
        /// <summary>
        /// User, as provided in the import file
        /// </summary>
        [JsonProperty("user")]
        public object User { get; set; }
        
        /// <inheritdoc cref="Error"/>
        [JsonProperty("errors")]
        public Error[] Errors { get; set; }
    }

    /// <summary>
    /// Errors importing the user.
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Error code.
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }
        
        /// <summary>
        /// Error message.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }
        
        /// <summary>
        /// Error field.
        /// </summary>
        [JsonProperty("path")]
        public string Path { get; set; }
    }
}