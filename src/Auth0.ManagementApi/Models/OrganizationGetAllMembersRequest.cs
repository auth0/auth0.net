namespace Auth0.ManagementApi.Models
{
    public class OrganizationGetAllMembersRequest {

        /// <summary>
        /// A comma separated list of fields to include or exclude (depending on <see cref="IncludeFields"/>) from the result, empty to retrieve all fields.
        /// </summary>
        /// <remarks>
        /// If fields is left blank, all fields (except roles) are returned.
        /// 
        /// Member roles are not sent by default.
        /// Use fields=roles to retrieve the roles assigned to each listed member.
        /// To use this parameter, you must include the read:organization_member_roles scope in the token.
        /// </remarks>
        public string Fields { get; set; } = null;

        /// <summary>
        /// Specifies whether the fields specified in <see cref="Fields"/> should be included or excluded in the result.
        /// </summary>
        public bool? IncludeFields { get; set; } = null;
    }
}