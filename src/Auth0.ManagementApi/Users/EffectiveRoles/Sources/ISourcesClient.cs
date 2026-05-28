namespace Auth0.ManagementApi.Users.EffectiveRoles.Sources;

public partial interface ISourcesClient
{
    public IGroupsClient Groups { get; }
}
