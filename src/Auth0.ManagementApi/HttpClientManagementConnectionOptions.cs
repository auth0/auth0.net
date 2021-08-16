namespace Auth0.ManagementApi
{
    public class HttpClientManagementConnectionOptions
    {
        /// <summary>
        ///  Set the maximum number of consecutive retries for Management API requests that fail due to rate-limits being reached.
        ///  By default, rate-limited requests will be retries a maximum of three times.To disable retries on rate-limit
        ///  errors, set this value to zero.
        /// </summary>
        /// <remarks>Must be a number between zero (do not retry) and ten.</remarks>
        public int? NumberOfHttpRetries { get; set; }
    }
}