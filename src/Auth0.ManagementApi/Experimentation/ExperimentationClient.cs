using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Experimentation;

public partial class ExperimentationClient : IExperimentationClient
{
    private readonly RawClient _client;

    internal ExperimentationClient(RawClient client)
    {
        _client = client;
        Experiments = new ExperimentsClient(_client);
        FeatureFlags = new FeatureFlagsClient(_client);
        Segments = new SegmentsClient(_client);
    }

    public IExperimentsClient Experiments { get; }

    public IFeatureFlagsClient FeatureFlags { get; }

    public ISegmentsClient Segments { get; }
}
