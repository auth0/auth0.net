namespace Auth0.ManagementApi.Guardian;

public partial interface IGuardianClient
{
    public IEnrollmentsClient Enrollments { get; }
    public IFactorsClient Factors { get; }
    public IPoliciesClient Policies { get; }
}
