namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// User-specific representation of a permission, including its source(s).
    /// </summary>
    public class UserPermission : Permission
    {
        /// <summary>
        /// Gets or sets the source(s) of the permission.
        /// </summary>
        public PermissionSource[] Sources { get; set; }
    }
}
