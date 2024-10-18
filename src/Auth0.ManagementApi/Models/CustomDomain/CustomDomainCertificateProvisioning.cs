using System.Runtime.Serialization;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// The custom domain provisioning type.
    /// </summary>
    public enum CustomDomainCertificateProvisioning
    {
        /// <summary>
        /// Using Auth0-managed Certificates.
        /// </summary>
        [EnumMember(Value = "auth0_managed_certs")]
        Auth0ManagedCertificate,

        /// <summary>
        /// Using self-managed certificates.
        /// </summary>
        [EnumMember(Value = "self_managed_certs")]
        SelfManagedCertificate
    }
}