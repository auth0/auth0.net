namespace Auth0.ManagementApi.Organizations.Roles;

public partial interface IRolesClient
{
    public IMembersClient Members { get; }
}
