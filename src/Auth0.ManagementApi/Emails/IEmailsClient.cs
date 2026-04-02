namespace Auth0.ManagementApi.Emails;

public partial interface IEmailsClient
{
    public IProviderClient Provider { get; }
}
