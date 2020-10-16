using System.Runtime.Serialization;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Enum used to define the expected format for the users exports job
    /// </summary>
    public enum UsersExportsJobFormat
    {
        /// <summary>
        /// Export the users using the CSV format.
        /// </summary>
        [EnumMember(Value = "csv")]
        CSV,
        
        /// <summary>
        /// Export the users using the JSON format.
        /// </summary>
        [EnumMember(Value = "json")]
        JSON
    }
}
