namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// User-specific representation of a user, including permission sources
    /// </summary>
    public class UserPermission : Permission
    {
        /// <summary>
        /// Gets or sets the source(s) of the permission
        /// </summary>
        public PermissionSource[] Sources { get; set; }
    }
}
