namespace Auth0.ManagementApi.Organizations.Members.EffectiveRoles.Sources;

public partial interface ISourcesClient
{
    public IGroupsClient Groups { get; }
}
