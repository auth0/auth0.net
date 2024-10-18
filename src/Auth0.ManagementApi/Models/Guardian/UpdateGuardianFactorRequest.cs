namespace Auth0.ManagementApi.Models
{
    public class UpdateGuardianFactorRequest : UpdateGuardianFactorBase
    {
        /// <summary>
        /// The Guardian factor to update.
        /// </summary>
        public GuardianFactorName Factor { get; set; }
    }
}