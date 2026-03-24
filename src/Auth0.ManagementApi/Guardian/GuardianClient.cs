using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Guardian;

public partial class GuardianClient : IGuardianClient
{
    private readonly RawClient _client;

    internal GuardianClient(RawClient client)
    {
        _client = client;
        Enrollments = new EnrollmentsClient(_client);
        Factors = new FactorsClient(_client);
        Policies = new PoliciesClient(_client);
    }

    public IEnrollmentsClient Enrollments { get; }

    public IFactorsClient Factors { get; }

    public IPoliciesClient Policies { get; }
}
