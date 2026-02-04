using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.RiskAssessments;

public partial class RiskAssessmentsClient : IRiskAssessmentsClient
{
    private RawClient _client;

    internal RiskAssessmentsClient(RawClient client)
    {
        _client = client;
        Settings = new SettingsClient(_client);
    }

    public ISettingsClient Settings { get; }
}
