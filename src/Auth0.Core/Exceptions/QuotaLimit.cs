namespace Auth0.Core.Exceptions
{
    /// <summary>
    /// Represents the Client Quota Headers returned as part of the response.
    /// </summary>
    public class ClientQuotaLimit
    {
        public QuotaLimit PerHour { get; set; }
        public QuotaLimit PerDay { get; set; }
    }

    /// <summary>
    /// Represents the Organization Quota Headers returned as part of the response.
    /// </summary>
    public class OrganizationQuotaLimit
    {
        public QuotaLimit PerHour { get; set; }
        public QuotaLimit PerDay { get; set; }
    }

    /// <summary>
    /// Represents the structure of the quota limit headers returned as part of the response.
    /// </summary>
    public class QuotaLimit
    {
        /// <summary>
        /// The current configured quota
        /// </summary>
        public int Quota { get; set; }
        
        /// <summary>
        /// The remaining quota
        /// </summary>
        public int Remaining { get; set; }
        
        /// <summary>
        /// Remaining number of seconds when the quota resets.
        /// </summary>
        public int ResetAfter { get; set; }
    }
}