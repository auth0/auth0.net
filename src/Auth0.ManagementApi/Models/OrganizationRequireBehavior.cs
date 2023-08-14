using System.Runtime.Serialization;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Defines how to proceed during an authentication transaction when organization usage is required.
    /// </summary>
    public enum OrganizationRequireBehavior
    {
        /// <summary>
        /// Do not prompt for an organization
        /// </summary>
        [EnumMember(Value = "no_prompt")]
        NoPrompt,

        /// <summary>
        /// Prompt for an organization before login
        /// </summary>
        [EnumMember(Value = "pre_login_prompt")]
        PreLoginPrompt,


        /// <summary>
        /// Prompt for an organization after login
        /// </summary>
        [EnumMember(Value = "post_login_prompt")]
        PostLoginPrompt,
    }
}